using Microsoft.Extensions.DependencyInjection;

namespace AnosuApi;

public static class AnosuApiServicesExtension
{
    public static IServiceCollection AddAnosuRestfulApi(this IServiceCollection services)
    {
        if(!services.Any(x => x.ServiceType == typeof(IHttpClientFactory)))
        {
            services.AddHttpClient(nameof(AnosuRestfulApi));
        }
        services.AddSingleton<AnosuRestfulApi>();
        return services;
    }
}