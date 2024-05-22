using Restaurante.Core.Application.Dtos.Account;
using Restaurante.Infrastructure.Identity.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace Restaurante.Infraestructure.Identity.Interfaces
{
    public interface IJwtService
    {
        Task<JwtSecurityToken> GenerateJwToken(ApplicationUser user);
        RefreshToken GenerateRefreshToken();
    }
}
