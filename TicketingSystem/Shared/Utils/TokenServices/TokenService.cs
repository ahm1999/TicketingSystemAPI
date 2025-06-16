using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TicketingSystem.Features.AuthUserFeature;

namespace TicketingSystem.Shared.Utils.TokenServices
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;

        public TokenService(IConfiguration config)
        {
            _config = config;
        }
        public string CreateToken(AuthUser user)
        {
            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetValue<string>("JwtSecret")!));
            var signingCreds = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha512);


            var Claims = new List<Claim>(){

                new Claim(ClaimTypes.Sid,user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email??""),
                new Claim(ClaimTypes.Role,user.User!.role!)

            };

            var token = new JwtSecurityToken("TicketingSystemAPI", "client", Claims, expires: DateTime.Now.AddHours(2), signingCredentials: signingCreds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
