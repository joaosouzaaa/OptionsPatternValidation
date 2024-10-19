using FluentValidation;
using System.Reflection;

namespace OptionsPatternValidation.API.DependencyInjection;

internal static class DependencyInjectionHandler
{
    internal static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCorsDependencyInjection();
        services.AddSwaggerDependencyInjection();

        services.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(Program)));

        services.AddOptionsDependencyInjection();
        services.AddAuthenticationDependencyInjection(configuration);
        services.AddServicesDependencyInjection();
    }
}
