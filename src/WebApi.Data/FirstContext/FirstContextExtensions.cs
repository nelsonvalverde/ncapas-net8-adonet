using WebApi.Data.FirstContext.DbContext;
using WebApi.Data.FirstContext.DbContext.Impl;
using WebApi.Data.FirstContext.Repositories;
using WebApi.Data.FirstContext.Repositories.Impl.ErrorRepository;
using WebApi.Data.FirstContext.Repositories.Impl.JobLogRepository;
using WebApi.Data.FirstContext.Repositories.Impl.SessionRepository;
using WebApi.Data.FirstContext.Repositories.Impl.UserClaimRepository;
using WebApi.Data.FirstContext.Repositories.Impl.UserRepository;
using WebApi.Data.FirstContext.Repositories.Impl.UserRoleRepository;
using WebApi.Data.FirstContext.UnitOfWork;
using WebApi.Data.FirstContext.UnitOfWork.Impl;

namespace WebApi.Data.FirstContext;

public static class FirstContextExtensions
{
    public static IServiceCollection AddFirstContextExtensions(this IServiceCollection services)
    {
        #region Context

        services.AddSingleton<IFirstDbContext, FirstDbContext>();
        services.AddScoped<IFirstUnitOfWork, FirstUnitOfWork>();

        #endregion Context

        #region Repositories

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        services.AddScoped<IUserClaimRepository, UserClaimRepository>();
        services.AddScoped<ISessionRepository, SessionRepository>();
        services.AddScoped<IErrorRepository, ErrorRepository>();
        services.AddScoped<IJobLogRepository, JobLogRepository>();

        #endregion Repositories

        return services;
    }
}