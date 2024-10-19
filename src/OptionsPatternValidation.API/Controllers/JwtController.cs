using Microsoft.AspNetCore.Mvc;
using OptionsPatternValidation.API.Interfaces.Services;

namespace OptionsPatternValidation.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class JwtController(IJwtService jwtService) : ControllerBase
{
    [HttpGet("generate-token")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public string GenerateToken() =>
        jwtService.GenerateToken();
}
