using Microsoft.Extensions.DependencyInjection;

namespace PawalApi;

public static class PawalApiServicesExtension
{
    public static IServiceCollection AddPawalRestfulApi(this IServiceCollection services)
    {
        if(!services.Any(x => x.ServiceType == typeof(IHttpClientFactory)))
        {
            services.AddHttpClient(nameof(PawalRestfulApi));
        }
        services.AddSingleton<IPawalApi,PawalRestfulApi>();
        return services;
    }
}