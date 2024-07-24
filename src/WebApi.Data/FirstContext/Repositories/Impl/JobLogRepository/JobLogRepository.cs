using WebApi.Data.FirstContext.DbContext;
using WebApi.Entities.JobLog.Dtos;
using static WebApi.Data.Factory.DbFactory.Impl.DbSchema;

namespace WebApi.Data.FirstContext.Repositories.Impl.JobLogRepository;

public sealed class JobLogRepository(
    IFirstDbContext dbContext
) : IJobLogRepository
{
    private readonly IFirstDbContext _dbContext = dbContext;

    public async Task Create(CreateJobLogDto createJobLog, CancellationToken cancellationToken = default)
    {
        var parameters = new SqlParameter[]
     {
            new ("@INSTANCE_ID", createJobLog.InstanceId),
            new ("@TRIGGER_GROUP", createJobLog.TriggerGroup),
            new ("@TRIGGER_NAME", createJobLog.TriggerName),
            new ("@JOB_NAME", createJobLog.JobName),
            new ("@JOB_FULL_PATH", createJobLog.JobFullPath),
            new ("@JOB_CRON_EXPRESSION", createJobLog.JobCronExpression),
            new ("@JOB_REGISTERED", createJobLog.Registered),
            new ("@STATUS_ID", createJobLog.StatusId),
            new ("@JOB_ERROR_TYPE", createJobLog.JobErrorType),
            new ("@JOB_ERROR_MESSAGE", createJobLog.JobErrorMessage),
            new ("@JOB_ERROR_STACKTRACE", createJobLog.JobErrorStacktrace)
     };

        await _dbContext.ExecuteScalarAsync<string>(Schema.log, "PROJ_CREATE_JOB_LOG", parameters, cancellationToken);
    }
}