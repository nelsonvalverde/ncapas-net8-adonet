using System.Security.Claims;
using WebApi.Business.UseCases.Users.Common.Dtos;
using WebApi.Entities.User.Dtos;

namespace WebApi.Business.Common.Services.TokenService;

public interface ITokenService
{
    Task<UserAuthDto> GenerateUserToken(UserDto user);

    Task<IEnumerable<Claim>> GetClaims(string userId);
}