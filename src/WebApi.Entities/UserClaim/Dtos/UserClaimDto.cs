using WebApi.Entities.UserClaim.Enums;

namespace WebApi.Entities.UserClaim.Dtos;

public sealed record UserClaimDto(
    string Id,
    string UserId,
    string Type,
    string Value,
    UserClaimStatus StatusId
);