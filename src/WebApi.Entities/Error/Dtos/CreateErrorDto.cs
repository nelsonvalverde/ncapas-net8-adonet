namespace WebApi.Entities.Error.Dtos;

public sealed record CreateErrorDto(
    string App,
    string Type,
    string Message,
    string Body,
    string Method,
    string Path,
    string QueryString,
    string UserAgent,
    string StackTrace
);