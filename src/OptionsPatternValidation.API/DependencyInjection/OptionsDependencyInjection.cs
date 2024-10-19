using FluentValidation;
using OptionsPatternValidation.API.Constants;
using OptionsPatternValidation.API.Options;

namespace OptionsPatternValidation.API.DependencyInjection;

internal static class OptionsDependencyInjection
{
    internal static void AddOptionsDependencyInjection(this IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();

        services.AddOptions<TokenOptions>()
                .BindConfiguration(OptionsConstants.TokenSection)
                .Validate(tokenOptions =>
                {
                    var validator = serviceProvider.GetRequiredService<IValidator<TokenOptions>>();

                    var validationResult = validator.Validate(tokenOptions);

                    return validationResult.IsValid;
                })
                .ValidateOnStart();
    }
}