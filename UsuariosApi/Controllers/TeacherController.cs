using CpsForum.Data.Dtos;
using CpsForum.Services;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Services;

namespace CpsForum.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class TeacherController : ControllerBase
    {
        private ProfessorService _professorService;

        public TeacherController(ProfessorService professorService)
        {
            _professorService = professorService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(CreateTeacherDto dto)
        {
            await _professorService.Register(dto);

            return Ok("Professor cadastrado!");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginTeacherDto dto)
        {
            var token = await _professorService.Login(dto);
            return Ok(token);
        }
    }
}

