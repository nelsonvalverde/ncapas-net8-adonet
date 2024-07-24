using WebApi.Data.FirstContext.DbContext;
using WebApi.Data.FirstContext.Repositories;

namespace WebApi.Data.FirstContext.UnitOfWork.Impl;

public class FirstUnitOfWork : IFirstUnitOfWork
{
    private readonly IFirstDbContext _dbContext;
    private readonly IUserRepository _userRepository;
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IUserClaimRepository _userClaimRepository;
    private readonly ISessionRepository _sessionRepository;
    private readonly IErrorRepository _errorRepository;
    private readonly IJobLogRepository _jobLogRepository;
    private bool _disposed;

    public FirstUnitOfWork(
        IFirstDbContext dbContext,
        IUserRepository userRepository,
        IUserRoleRepository userRoleRepository,
        IUserClaimRepository userClaimRepository,
        ISessionRepository sessionRepository,
        IErrorRepository errorRepository,
        IJobLogRepository jobLogRepository)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _dbContext.OpenConnectionAndKeepOpen();
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _userRoleRepository = userRoleRepository ?? throw new ArgumentNullException(nameof(userRoleRepository));
        _userClaimRepository = userClaimRepository ?? throw new ArgumentNullException(nameof(userClaimRepository));
        _sessionRepository = sessionRepository ?? throw new ArgumentNullException(nameof(sessionRepository));
        _errorRepository = errorRepository ?? throw new ArgumentNullException(nameof(errorRepository));
        _jobLogRepository = jobLogRepository ?? throw new ArgumentNullException(nameof(jobLogRepository));
    }

    public IUserRepository UserRepository => _userRepository;
    public IUserRoleRepository UserRoleRepository => _userRoleRepository;
    public IUserClaimRepository UserClaimRepository => _userClaimRepository;
    public ISessionRepository SessionRepository => _sessionRepository;
    public IErrorRepository ErrorRepository => _errorRepository;
    public IJobLogRepository JobLogRepository => _jobLogRepository;

    #region Methods

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _dbContext.DisposeConnection();
            }

            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    #endregion Methods
}