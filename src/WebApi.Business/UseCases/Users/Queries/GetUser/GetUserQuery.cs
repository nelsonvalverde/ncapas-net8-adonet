using WebApi.Business.Common.Responses.Base;
using WebApi.Entities.User.Dtos;

namespace WebApi.Business.UseCases.Users.Queries.GetUser;

public sealed record GetUserQuery(
    string Id
) : IRequest<ResponseBase<UserDto>>;