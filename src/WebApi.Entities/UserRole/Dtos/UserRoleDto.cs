namespace WebApi.Entities.UserRole.Dtos;

public record UserRoleDto(
    string UserId,
    string RoleId,
    string? CreatedBy,
    DateTime? Created,
    string? LastModifiedBy,
    DateTime? LastModified);