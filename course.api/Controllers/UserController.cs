using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using course.api.Business.Entities;
using course.api.Business.Repositories;
using course.api.Configuration;
using course.api.Filters;
using course.api.Infra.Data;
using course.api.Models;
using course.api.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;

namespace course.api.Controllers
{

    [Route("api/v1/user")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationService _authenticationService;
        public UserController(
            IUserRepository userRepository,
            IAuthenticationService authenticationService)
        {
            _userRepository = userRepository;
            _authenticationService = authenticationService;
        }

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


            return Ok(new
            {
                token = _authenticationService.GenerateToken(userViewModelOutput),
                user = userViewModelOutput
            });
        }

        [HttpPost]
        [Route("register")]
        [ValidationModalStateCustomized]
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao criar o usuário")]
        public IActionResult Register(RegisterViewModelInput registerViewModelInput)
        {

            _userRepository.Add(new User()
            {
                Login = registerViewModelInput.Login,
                Email = registerViewModelInput.Email,
                Senha = registerViewModelInput.Password

            });

            return Created("Ok", registerViewModelInput);
        }

    }
}