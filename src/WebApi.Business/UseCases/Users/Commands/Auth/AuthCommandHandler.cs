﻿using WebApi.Business.Common.Error;
using WebApi.Business.Common.Responses.Base;
using WebApi.Business.Common.Services.TokenService;
using WebApi.Business.UseCases.Users.Common.Dtos;
using WebApi.Data.FirstContext.UnitOfWork;
using WebApi.Entities.Session.Enums;
using WebApi.Shared.Services.PasswordHashService;

namespace WebApi.Business.UseCases.Users.Commands.Auth;

public sealed class AuthCommandHandler(
    IFirstUnitOfWork unitOfWork,
    ITokenService tokenService,
    IPasswordHashService passwordHashService) : IRequestHandler<AuthCommand, ResponseBase<UserAuthDto>>
{
    private readonly IFirstUnitOfWork _unitOfWork = unitOfWork;
    private readonly ITokenService _tokenService = tokenService;
    private readonly IPasswordHashService _passwordHashService = passwordHashService;

    public async Task<ResponseBase<UserAuthDto>> Handle(AuthCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.UserRepository.AuthUserAsync(request.Email, cancellationToken);
        var userHashedPassword = user?.PasswordHash ?? string.Empty;
        var passwordIsCorrect = _passwordHashService.VerifyPassword(request.Password, userHashedPassword);

        if (user is null || !passwordIsCorrect) throw new UnauthorizeException(MessageValidator.ErrorCredentials);

        var userTokenGenerated = await _tokenService.GenerateUserToken(user);

        return new ResponseBase<UserAuthDto>(userTokenGenerated);
    }
}