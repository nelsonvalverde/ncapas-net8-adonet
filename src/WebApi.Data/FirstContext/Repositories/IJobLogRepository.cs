using WebApi.Entities.JobLog.Dtos;

namespace WebApi.Data.FirstContext.Repositories;

public interface IJobLogRepository
{
    Task Create(CreateJobLogDto createJobLog, CancellationToken cancellationToken = default);
}
