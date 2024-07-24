using WebApi.Data.Factory.DbFactory.Impl;
using WebApi.Data.FirstContext.DbContext;
using WebApi.Entities.UserClaim.Dtos;

namespace WebApi.Data.FirstContext.Repositories.Impl.UserClaimRepository;

public sealed class UserClaimRepository(
    IFirstDbContext dbContext
    ) : IUserClaimRepository
{
    private readonly IFirstDbContext _dbContext = dbContext;

    public async Task<IEnumerable<UserClaimDto>> GetUserClaims(string userId, CancellationToken cancellationToken = default)
    {
        var userClaims = new List<UserClaimDto>();
        var parameters = new SqlParameter[]
        {
            new("@USER_ID", userId)
        };

        await _dbContext.DataReaderAsync(
           schema: DbSchema.Schema.dbo,
           storedProcedure: "PROJ_GET_USER_CLAIMS_BY_USER_ID_SP",
           readerAction: (reader) =>
           {
               userClaims.Add(UserClaimMapper.ToUserClaimDto(reader));
           },
           parameters: parameters,
           cancellationToken: cancellationToken
        );

        return userClaims;
    }
}