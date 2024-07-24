using WebApi.Entities.Base;
using WebApi.Entities.User.Dtos;

namespace WebApi.Data.FirstContext.Repositories;

public interface IUserRepository
{ 
    Task CreateAsync(CreateUserDto user, CancellationToken cancellationToken = default);

    Task UpdateAsync(UpdateUserDto user, CancellationToken cancellationToken = default);

    Task UpdateUserStatusAsync(UpdateUserStatusDto user, CancellationToken cancellationToken = default);

    Task<UserDto?> GetByIdAsync(string id, CancellationToken cancellationToken = default);

    Task<UserDto?> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default);

    Task<UserDto?> AuthUserAsync(string email, CancellationToken cancellationToken = default);

    Task<DataPage<UserDto>> GetPageAsync(string? filterName = null, int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default);

    Task<DataList<UserDto>> FilterAsync(string? filterName = null, CancellationToken cancellationToken = default);
}