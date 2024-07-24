using WebApi.Data.FirstContext.Repositories;

namespace WebApi.Data.FirstContext.UnitOfWork;

public interface IFirstUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }
    IUserRoleRepository UserRoleRepository { get; }
    ISessionRepository SessionRepository { get; }
    IErrorRepository ErrorRepository { get; }
    IUserClaimRepository UserClaimRepository { get; }
    IJobLogRepository JobLogRepository { get; }
}