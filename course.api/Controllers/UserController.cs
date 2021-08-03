using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using course.api.Filters;
using course.api.Models;
using course.api.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;

namespace course.api.Controllers
{

    [Route("api/v1/user")]
    [ApiController]
    public class UserController : ControllerBase
    {

        /// <summary>
        /// Esse serviço permite autenticar um usuário cadastrado e ativo
        /// </summary>
        /// <param name="loginViewModelInput">View model do login</param>
        /// <returns>Retorna Ok, dados do usuário e o token em caso de sucesso</returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ValidateViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro Interno", Type = typeof(GenericErrorViewModel))]
        [HttpPost]
        [Route("login")]
        [ValidationModalStateCustomized]
        public IActionResult Login(LoginViewModelInput loginViewModelInput)
        {

            var userViewModelOutput = new UserViewModelOutput
            {
                Id = 2,
                Name = "Eglison",
                Email = "e@e.com"
            };


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
            var token = jwtSecurityTokenHandler.WriteToken(tokenGenerated);

            return Ok(new
            {
                token = token,
                user = userViewModelOutput
            });
        }

        [HttpPost]
        [Route("register")]
        [ValidationModalStateCustomized]
        public IActionResult Register(RegisterViewModelInput registerViewModelInput)
        {
            return Created("", registerViewModelInput);
        }

    }
}