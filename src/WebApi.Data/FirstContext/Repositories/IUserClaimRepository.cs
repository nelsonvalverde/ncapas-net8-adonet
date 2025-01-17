﻿using WebApi.Entities.UserClaim.Dtos;

namespace WebApi.Data.FirstContext.Repositories;

public interface IUserClaimRepository 
{ 
    Task<IEnumerable<UserClaimDto>> GetUserClaims(string userId, CancellationToken cancellationToken = default);
}