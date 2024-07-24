using WebApi.Business.Common.Error;
using WebApi.Business.Common.Responses.Base;
using WebApi.Data.FirstContext.UnitOfWork;
using WebApi.Entities.User.Dtos;

namespace WebApi.Business.UseCases.Users.Queries.GetUser;

public sealed class GetUserQueryHandler(
        IFirstUnitOfWork unitOfWork
    )
    : IRequestHandler<GetUserQuery, ResponseBase<UserDto>>
{
    private readonly IFirstUnitOfWork _unitOfWork= unitOfWork;

    public async Task<ResponseBase<UserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.UserRepository.GetByIdAsync(request.Id, cancellationToken);
        return user is null ? throw new NotFoundException("User doest not exist") : new ResponseBase<UserDto>(user);
    }
}