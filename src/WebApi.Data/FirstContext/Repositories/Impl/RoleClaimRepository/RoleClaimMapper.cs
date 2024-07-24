using WebApi.Entities.RoleClaim.Dtos;
using WebApi.Entities.RoleClaim.Enums;

namespace WebApi.Data.FirstContext.Repositories.Impl.RoleClaimRepository;

public static class RolelClaimMapper
{
    public static RoleClaimDto ToRoleClaimDto(SqlDataReader dataReader)
    {
        return new(
            Id: ReaderConvert.ToString(dataReader, "ROLE_CLAIM_ID"),
            RoleId: ReaderConvert.ToString(dataReader, "ROLE_CLAIM_ROLE_ID"),
            Type: ReaderConvert.ToString(dataReader, "ROLE_CLAIM_TYPE"),
            Value: ReaderConvert.ToString(dataReader, "ROLE_CLAIM_VALUE"),
            StatusId: (RoleClaimStatus)ReaderConvert.ToShort(dataReader, "ROLE_CLAIM_STATUS_ID")
        );
    }
}