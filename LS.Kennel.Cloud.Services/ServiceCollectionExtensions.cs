using LS.Kennel.Cloud.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace LS.Kennel.Cloud.Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddKennelServices(this IServiceCollection services)
    {
        services.AddScoped<IKennelService, KennelService>();
        services.AddScoped<IDogService, DogService>();
        services.AddScoped<IHeatService, HeatService>();
        return services;
    }
}
