using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OptionsPatternValidation.API.Interfaces.Services;
using OptionsPatternValidation.API.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OptionsPatternValidation.API.Services;

public sealed class JwtService(IOptions<TokenOptions> tokenOptions) : IJwtService
{
    private readonly TokenOptions _token = tokenOptions.Value;

    public string GenerateToken()
    {
        var claims = new List<Claim>()
        {
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        }; 

        var tokenDescription = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_token.ExpirationTimeInMinutes)),
            Issuer = _token.Issuer,
            Audience = _token.Audience,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_token.Key)),
                SecurityAlgorithms.HmacSha256)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescription);

        return tokenHandler.WriteToken(token);
    }
}
