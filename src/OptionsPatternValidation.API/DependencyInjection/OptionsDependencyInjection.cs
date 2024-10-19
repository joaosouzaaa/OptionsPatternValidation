using OptionsPatternValidation.API.Constants;
using OptionsPatternValidation.API.Options;

namespace OptionsPatternValidation.API.DependencyInjection;

internal static class OptionsDependencyInjection
{
    internal static void AddOptionsDependencyInjection(this IServiceCollection services, IConfiguration configuration) =>
        services.Configure<TokenOptions>(configuration.GetSection(OptionsConstants.TokenSection));
}
