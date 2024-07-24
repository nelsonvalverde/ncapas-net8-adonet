using WebApi.Entities.Error.Dtos;

namespace WebApi.Data.FirstContext.Repositories;

public interface IErrorRepository
{
    Task<string> CreateError(CreateErrorDto createErrorDto, CancellationToken cancellationToken = default);
    Task ClearErrors(CancellationToken cancellationToken = default);
}
