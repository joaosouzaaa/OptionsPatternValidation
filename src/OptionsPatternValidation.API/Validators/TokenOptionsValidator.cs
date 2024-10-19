using FluentValidation;
using OptionsPatternValidation.API.Options;
using System.Text;

namespace OptionsPatternValidation.API.Validators;

public sealed class TokenOptionsValidator : AbstractValidator<TokenOptions>
{
    public TokenOptionsValidator()
    {
        RuleFor(t => t.Key)
            .Must(k =>
            {
                byte[] keyBytes = Encoding.UTF8.GetBytes(k);

                return keyBytes.Length >= 32;
            });

        RuleFor(t => t.Issuer).NotEmpty();

        RuleFor(t => t.Audience).NotEmpty();

        RuleFor(t => t.ExpirationTimeInMinutes).GreaterThanOrEqualTo(5);
    }
}
