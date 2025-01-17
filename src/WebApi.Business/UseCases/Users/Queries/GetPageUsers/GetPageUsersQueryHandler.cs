﻿using WebApi.Business.Common.Responses.Base;
using WebApi.Data.FirstContext.Repositories;
using WebApi.Entities.Base;
using WebApi.Entities.User.Dtos;

namespace WebApi.Business.UseCases.Users.Queries.GetPageUsers;

public sealed class GetPageUsersQueryHandler
    (
        IUserRepository userRepository
    )
    : IRequestHandler<GetPageUsersQuery, ResponseBase<DataPage<UserDto>>>
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<ResponseBase<DataPage<UserDto>>> Handle(GetPageUsersQuery request, CancellationToken cancellationToken)
    {
        var userPages = await _userRepository.GetPageAsync(request.FilterName, request.PageNumber, request.PageSize, cancellationToken);
        return new ResponseBase<DataPage<UserDto>>(userPages);
    }
}