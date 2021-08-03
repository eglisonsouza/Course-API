using System.Linq;
using course.api.Filters;
using course.api.Models;
using course.api.Models.Users;
using Microsoft.AspNetCore.Mvc;
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
            return Ok(loginViewModelInput);
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