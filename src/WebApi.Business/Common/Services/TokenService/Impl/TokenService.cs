using System.Security.Claims;
using WebApi.Business.UseCases.Users.Common.Dtos;
using WebApi.Business.UseCases.Users.Common.Mappers;
using WebApi.Data.FirstContext.UnitOfWork;
using WebApi.Entities.Session.Dtos;
using WebApi.Entities.Session.Enums;
using WebApi.Entities.User.Dtos;
using WebApi.Shared.Services.JwtService;
using WebApi.Shared.Services.JwtService.Models;

namespace WebApi.Business.Common.Services.TokenService.Impl;

public sealed class TokenService(
    IFirstUnitOfWork unitOfWork,
    IJwtService jwtService
    ) : ITokenService
{
    private readonly IFirstUnitOfWork _unitOfWork = unitOfWork;
    private readonly IJwtService _jwtService = jwtService;

    public async Task<UserAuthDto> GenerateUserToken(UserDto user)
    {
        var customClaims = await GetClaims(user.Id);
        var tokenGenerated = _jwtService.GenerateToken(new JwtUser(user.Id, user.Name, user.Email), customClaims);
        var userAuth = new UserAuthDto(user.ToUserAuth(), tokenGenerated.Token, tokenGenerated.RefreshToken);
        await _unitOfWork.SessionRepository.CreateAsync(new CreateSessionDto(
            Id: Guid.NewGuid().ToString("D"),
            UserId: user.Id,
            Token: tokenGenerated.Token,
            RefreshToken: tokenGenerated.RefreshToken,
            StatusId: SessionStatus.Active,
            Expires: tokenGenerated.Expires
        ));

        return userAuth;
    }

    public async Task<IEnumerable<Claim>> GetClaims(string userId)
    {
        var userClaims = await _unitOfWork.UserClaimRepository.GetUserClaims(userId);
        var roleClaims = await _unitOfWork.UserRoleRepository.GetRoleClaimsByUser(userId);
        return [
            ..userClaims.Select(x => new Claim(x.Type, x.Value)),
            ..roleClaims.Select(x => new Claim(x.Type, x.Value))
        ];
    }
}