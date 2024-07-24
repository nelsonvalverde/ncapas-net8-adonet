using WebApi.Entities.UserClaim.Dtos;
using WebApi.Entities.UserClaim.Enums;

namespace WebApi.Data.FirstContext.Repositories.Impl.UserClaimRepository;

public static class UserClaimMapper
{
    public static UserClaimDto ToUserClaimDto(SqlDataReader dataReader)
    {
        return new(
            Id: ReaderConvert.ToString(dataReader, "USER_CLAIM_ID"),
            UserId: ReaderConvert.ToString(dataReader, "USER_CLAIM_USER_ID"),
            Type: ReaderConvert.ToString(dataReader, "USER_CLAIM_TYPE"),
            Value: ReaderConvert.ToString(dataReader, "USER_CLAIM_VALUE"),
            StatusId: (UserClaimStatus)ReaderConvert.ToShort(dataReader, "USER_CLAIM_STATUS_ID")
        );
    }
}