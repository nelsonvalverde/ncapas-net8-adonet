using WebApi.Business.Common.Error;
using WebApi.Business.Common.Responses.Base;
using WebApi.Business.Common.Services.TokenService;
using WebApi.Business.UseCases.Users.Common.Dtos;
using WebApi.Data.FirstContext.UnitOfWork;
using WebApi.Entities.Session.Dtos;
using WebApi.Entities.Session.Enums;
using WebApi.Shared.Services.UserService;

namespace WebApi.Business.UseCases.Users.Commands.RefreshToken;

public sealed class RefreshTokenCommandHandler(
    IFirstUnitOfWork unitOfWork,
    IUserService userService,
    ITokenService tokenService) : IRequestHandler<RefreshTokenCommand, ResponseBase<UserAuthDto>>
{
    private readonly IFirstUnitOfWork _unitOfWork = unitOfWork;
    private readonly IUserService _userService = userService;
    private readonly ITokenService _tokenService = tokenService;

    public async Task<ResponseBase<UserAuthDto>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.UserRepository.GetByIdAsync(_userService.UserId, cancellationToken);
        if (user is null) throw new ForbiddenException(MessageValidator.UserDoestnExist);
        var token = await _tokenService.GenerateUserToken(user);
        await _unitOfWork.SessionRepository.UpdateByRefreshToken(new RefreshSessionDto(
            RefreshToken: _userService.RefreshToken,
            StatusId: SessionStatus.Expired
        ));
        return new ResponseBase<UserAuthDto>(token);
    }
}