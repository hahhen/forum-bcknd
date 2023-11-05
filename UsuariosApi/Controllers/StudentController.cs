using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Services;

namespace CpsForum.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UserController : ControllerBase
    {
        private UsuarioService _usuarioService;

        public UserController(UsuarioService cadastroService)
        {
            _usuarioService = cadastroService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(CreateStudentDto dto)
        {
            await _usuarioService.Register(dto);

            return Ok("Usuário Cadastrado!");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginStudentDto dto)
        {
            var token = await _usuarioService.Login(dto);
            return Ok(token);
        }
    }
}
