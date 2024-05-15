using System.Security.Claims;

namespace Estudos.Services.Api.Services
{
    public interface IJwtBearerTokenService
    {
        string CreateToken(List<Claim> claims);
    }
}
