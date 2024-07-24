using WebApi.Entities.Base;
using WebApi.Entities.RoleClaim.Dtos;
using WebApi.Entities.UserRole.Dtos;

namespace WebApi.Data.FirstContext.Repositories;

public interface IUserRoleRepository
{
    Task AssignRoleToUser(AssignUserRoleDto assign, CancellationToken cancellationToken = default);

    Task<DataList<UserRoleDto>> GetRolesByUser(string userId, CancellationToken cancellationToken = default);

    Task<IEnumerable<RoleClaimDto>> GetRoleClaimsByUser(string userId, CancellationToken cancellationToken = default);
}