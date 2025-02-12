using bookstore.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace bookstore.Services
{
    public class JwtService
    {

        public string GenerateJwt(User user)
        {
            var handler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration.PrivateJwtKey);

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature);

            var ci = new ClaimsIdentity();

            ci.AddClaim(new Claim("email", user.Email));
            ci.AddClaim(new Claim("active", user.Active.ToString().ToLower()));
            ci.AddClaim(new Claim("vip", user.Vip.ToString().ToLower()));


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = ci,
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(2)
            };
            var token = handler.CreateToken(tokenDescriptor);

            string strToken = handler.WriteToken(token);

            return strToken;
        }
    }
}
