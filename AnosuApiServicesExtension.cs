using Microsoft.Extensions.DependencyInjection;

namespace PawalApi;

public static class AnosuApiServicesExtension
{
    public static IServiceCollection AddAnosuApi(this IServiceCollection services)
    {
        if(!services.Any(x => x.ServiceType == typeof(IHttpClientFactory)))
        {
            services.AddHttpClient(nameof(IPawalApi));
        }
        services.AddSingleton<IPawalApi,AnosuRestfulApi>();
        return services;
    }
}