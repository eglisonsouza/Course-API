using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using course.api.Models.Users;
using Microsoft.IdentityModel.Tokens;

namespace course.api.Configuration
{
    public class JwtService : IAuthenticationService
    {
        public string GenerateToken(UserViewModelOutput userViewModelOutput)
        {
            var secret = Encoding.ASCII.GetBytes("qmdkanciepfjsoqo34n2k34");
            var symmetricSecurityKey = new SymmetricSecurityKey(secret);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userViewModelOutput.Id.ToString()),
                    new Claim(ClaimTypes.Name, userViewModelOutput.Name.ToString()),
                    new Claim(ClaimTypes.Email, userViewModelOutput.Email.ToString())
                }),
                Expires = System.DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenGenerated = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            return jwtSecurityTokenHandler.WriteToken(tokenGenerated);
        }
    }
}