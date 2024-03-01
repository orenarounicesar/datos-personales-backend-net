using Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions.Service;

public static class ServiceExtensions
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddTransient<PersonalInformationService>();

        return services;
    }
}