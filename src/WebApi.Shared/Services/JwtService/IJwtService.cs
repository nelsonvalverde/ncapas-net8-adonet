using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using WebApi.Shared.Services.JwtService.Models;

namespace WebApi.Shared.Services.JwtService;

public interface IJwtService
{
    JwtToken GenerateToken(JwtUser user, IEnumerable<Claim>? claims = null);

    ClaimsPrincipal ValidateToken(string token);

    TokenValidationParameters GetTokenValidationParameters();
}