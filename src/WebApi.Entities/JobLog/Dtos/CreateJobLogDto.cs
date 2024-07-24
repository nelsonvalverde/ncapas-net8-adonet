namespace WebApi.Entities.JobLog.Dtos;

public sealed record CreateJobLogDto(
    string InstanceId,
    string TriggerGroup,
    string TriggerName,
    string JobName,
    string JobFullPath,
    string JobCronExpression,
    DateTime Registered,
    string StatusId,
    string? JobErrorType = null,
    string? JobErrorMessage = null,
    string? JobErrorStacktrace = null
);