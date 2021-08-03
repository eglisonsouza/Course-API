using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using course.api.Models.Courses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace course.api.Controllers
{
    [Route("api/v1/course")]
    [ApiController]
    [Authorize]
    public class CourseController : ControllerBase
    {
        /// <summary>
        /// Este serviço permite cadastrar curso para o usuário autenticado
        /// </summary>
        /// <param name="courseViewModelInput"></param>
        /// <returns>Retorna status 2001 e dados do curso do usuário</returns>
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao cadastrar um curso")]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post(CourseViewModelInput courseViewModelInput)
        {
            var idUser = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            return Created("", courseViewModelInput);
        }

        /// <summary>
        /// Este serviço permite cadastrar curso para o usuário autenticado
        /// </summary>
        /// <returns>Retorna status 2001 e dados do curso do usuário</returns>
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao obter os curso")]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            var courses = new List<CourseViewModelOutput>();
            courses.Add(new CourseViewModelOutput()
            {
                Login = "Eglison",
                Name = "Arquitetura de Sistemas com C#",
                Description = "Esse curso é bom"
            });
            return Ok(courses);
        }
    }
}