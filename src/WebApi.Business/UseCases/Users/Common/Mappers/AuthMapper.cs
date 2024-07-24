using WebApi.Entities.User.Dtos;

namespace WebApi.Business.UseCases.Users.Common.Mappers;

public static class AuthMapper
{
    public static UserDto ToUserAuth(this UserDto user)
    {
        return user with { PasswordHash = null };
    }
}