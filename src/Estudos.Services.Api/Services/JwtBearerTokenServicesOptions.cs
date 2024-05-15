namespace Estudos.Services.Api.Services
{
    public class JwtBearerTokenServiceOptions
    {
        public string Issuer { get; set; }
        public string Key { get; set; }
        public int ExpiresInSeconds { get; set; }
    }
}
