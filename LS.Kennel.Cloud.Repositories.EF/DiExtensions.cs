using LS.Kennel.Cloud.Repositories.EF.Implementations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LS.Kennel.Cloud.Repositories.EF;

public static class DiExtensions
{
    public static IServiceCollection AddKennelEf(this IServiceCollection services, Action<DbContextOptionsBuilder>? optionsAction = null)
    {
        services.AddDbContext<ApplicationDbContext>(optionsAction);
        services.AddScoped<IKennelRepository, EfKennelRepository>();
        services.AddScoped<IDogRepository, EfDogRepository>();
        services.AddScoped<IHeatRepository, EfHeatRepository>();
        return services;
    }

    public static IdentityBuilder AddEfIdentity(this IdentityBuilder builder)
    {
        return builder.AddEntityFrameworkStores<ApplicationDbContext>();
    }
}