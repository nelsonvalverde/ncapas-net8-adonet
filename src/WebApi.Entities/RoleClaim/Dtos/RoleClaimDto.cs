using WebApi.Entities.RoleClaim.Enums;

namespace WebApi.Entities.RoleClaim.Dtos;

public sealed record RoleClaimDto(
    string Id,
    string RoleId,
    string Type,
    string Value,
    RoleClaimStatus StatusId
);