using OptionsPatternValidation.API.Interfaces.Services;
using OptionsPatternValidation.API.Services;

namespace OptionsPatternValidation.API.DependencyInjection;

internal static class ServicesDependencyInjection
{
    internal static void AddServicesDependencyInjection(this IServiceCollection services) =>
        services.AddScoped<IJwtService, JwtService>();
}
