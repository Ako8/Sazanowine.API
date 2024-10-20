using Microsoft.Extensions.DependencyInjection;
using Sazanowine.Application.Features.Users;


namespace Sazanowine.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(applicationAssembly));


        services.AddScoped<IUserContext, UserContext>();
        
        services.AddHttpContextAccessor();

    }
}
