using WebApi.Entities.User.Dtos;

namespace WebApi.Business.UseCases.Users.Common.Dtos;

public sealed record UserAuthDto(UserDto User, string Token, string RefreshToken);