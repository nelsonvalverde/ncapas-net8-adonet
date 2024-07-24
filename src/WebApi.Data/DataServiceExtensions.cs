using WebApi.Data.FirstContext;
using WebApi.Data.SecondContext;

namespace WebApi.Data;

public static class DataServiceExtensions
{
    public static IServiceCollection AddDataServiceExtensions(this IServiceCollection services)
    {
        services.AddFirstContextExtensions();
        services.AddSecondContextExtensions();
        return services;
    }
}