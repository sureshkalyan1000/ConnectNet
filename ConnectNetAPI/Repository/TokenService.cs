using ConnectNet.IRepository;
using ConnectNet.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ConnectNet.Repository
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration config;
        private readonly SymmetricSecurityKey secretKey;
        public TokenService(IConfiguration config)
        {
            this.secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["key"]));
        }
        public string GetTokenAsync(AppUser appuser)
        {
            var claims = new List<Claim>()
            {
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Name, appuser.UserName)
            };
            var cred = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);
            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = cred
            };
            var TokenHandler = new JwtSecurityTokenHandler();
            var token = TokenHandler.CreateToken(TokenDescriptor);
            return TokenHandler.WriteToken(token);

        }
    }
}
