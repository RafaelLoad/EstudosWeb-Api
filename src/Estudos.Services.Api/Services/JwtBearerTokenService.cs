using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Estudos.Services.Api.Services
{
    public class JwtBearerTokenService : IJwtBearerTokenService
    {
        private readonly JwtBearerTokenServiceOptions _options;
        public JwtBearerTokenService(IOptions<JwtBearerTokenServiceOptions> options)
        {
            _options = options.Value;
        }
        public string CriarToken(List<Claim> claims)
        {
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddSeconds(Convert.ToInt32(_options.ExpiresInSeconds)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.Key)), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _options.Issuer,
                IssuedAt = DateTime.UtcNow,
                Audience = _options.Issuer
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}