using WebApi.Data.SecondContext.DbContext;
using WebApi.Data.SecondContext.DbContext.Impl;
using WebApi.Data.SecondContext.Repositories;
using WebApi.Data.SecondContext.Repositories.Impl;
using WebApi.Data.SecondContext.UnitOfWork;
using WebApi.Data.SecondContext.UnitOfWork.Impl;

namespace WebApi.Data.SecondContext;

public static class SecondContextExtensions
{
    public static IServiceCollection AddSecondContextExtensions(this IServiceCollection services)
    {
        #region Context

        services.AddScoped<ISecondDbContext, SecondDbContext>();
        services.AddScoped<ISecondUnitOfWork, SecondUnitOfWork>();

        #endregion Context

        #region Repositories

        services.AddScoped<IEntityRepository, EntityRepository>();

        #endregion Repositories

        return services;
    }
}