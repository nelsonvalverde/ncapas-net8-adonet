using WebApi.Data.Factory.DbFactory.Impl;
using WebApi.Data.FirstContext.DbContext;
using WebApi.Data.FirstContext.Repositories.Impl.RoleClaimRepository;
using WebApi.Entities.Base;
using WebApi.Entities.RoleClaim.Dtos;
using WebApi.Entities.UserRole.Dtos;
using WebApi.Shared.Services.DateTimeService;
using WebApi.Shared.Services.UserService;

namespace WebApi.Data.FirstContext.Repositories.Impl.UserRoleRepository;

public sealed class UserRoleRepository(
    IFirstDbContext dbContext,
    IDateTimeService dateTimeService,
    IUserService userService) : IUserRoleRepository
{
    private readonly IFirstDbContext _dbContext = dbContext;
    private readonly IDateTimeService _dateTimeService = dateTimeService;
    private readonly IUserService _userService = userService;

    public async Task AssignRoleToUser(AssignUserRoleDto assign, CancellationToken cancellationToken = default)
    {
        var parameters = new SqlParameter[]
        {
            new("@USER_ID", assign.UserId),
            new("@ROLE_ID", assign.RoleId),
            new("@CREATED", _dateTimeService.GetDateTimeUtc),
            new("@CREATED_BY", _userService.UserId),
            new("@LAST_MODIFIED_BY", _userService.UserId),
            new("@LAST_MODIFIED", _dateTimeService.GetDateTimeUtc),
        };

        await _dbContext.ExecuteNonQueryAsync(DbSchema.Schema.dbo, "PROJ_ASSIGN_ROLE_TO_USER_SP", parameters, cancellationToken);
    }

    public async Task<DataList<UserRoleDto>> GetRolesByUser(string userId, CancellationToken cancellationToken = default)
    {
        var list = new List<UserRoleDto>();
        var parameters = new SqlParameter[]
        {
            new("@USER_ID", userId),
        };
        await _dbContext.DataReaderAsync(
            schema: DbSchema.Schema.dbo,
            storedProcedure: "PROJ_GET_USER_ROLES_BY_USER_ID_SP",
            readerAction: (reader) =>
            {
                list.Add(UserRoleMapper.ToUserRoleDto(reader));
            },
            parameters: parameters,
            cancellationToken: cancellationToken
        );
        return new DataList<UserRoleDto>
        {
            List = list,
            TotalRecord = list.Count
        };
    }

    public async Task<IEnumerable<RoleClaimDto>> GetRoleClaimsByUser(string userId, CancellationToken cancellationToken = default)
    {
        var userClaims = new List<RoleClaimDto>();
        var parameters = new SqlParameter[]
        {
            new("@USER_ID", userId)
        };

        await _dbContext.DataReaderAsync(
            schema: DbSchema.Schema.dbo,
            storedProcedure: "PROJ_GET_ROLE_CLAIMS_BY_USER_ID_SP",
            readerAction: (reader) =>
            {
                userClaims.Add(RolelClaimMapper.ToRoleClaimDto(reader));
            },
            parameters: parameters,
            cancellationToken: cancellationToken
        );

        return userClaims;
    }
}