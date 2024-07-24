using WebApi.Entities.User.Enums;

namespace WebApi.Entities.User.Dtos;

public record UserDto(
    string Id,
    string Name,
    string LastName,
    string FullName,
    string? PhoneNumber,
    string? PasswordHash,
    string Email,
    bool EmailConfirmed,
    UserStatus StatusId,
    DateOnly Birthday,
    string CreatedBy,
    DateTime Created,
    string LastModifiedBy,
    DateTime LastModified
);