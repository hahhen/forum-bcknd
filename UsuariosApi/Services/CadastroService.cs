using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class UsuarioService
    {
        private SignInManager<IdentityUser> _signInManagerUser;
        private TokenService _tokenService;
        private SendEmailService _sendEmailService;
        private IConfiguration _configuration;

        public IMapper _mapper { get; set; }
        public UserManager<IdentityUser> _userManager { get; set; }

        public UsuarioService(IMapper mapper, UserManager<IdentityUser> manager, SignInManager<IdentityUser> signInManager, TokenService tokenService, SendEmailService sendEmailService, IConfiguration configuration)
        {
            _mapper = mapper;
            _userManager = manager;
            _signInManagerUser = signInManager;
            _tokenService = tokenService;
            _sendEmailService = sendEmailService;
            _configuration = configuration;
        }

        public async Task Register(CreateStudentDto dto)
        {
            Usuario user = _mapper.Map<Usuario>(dto);

            IdentityResult result = await _userManager.CreateAsync(user, dto.Password);

            if (result.Succeeded)
            {
                if (dto.Email is not null)
                {
                    await _sendEmailService.ConstructorEmail(dto, _configuration["EmailSettings"], _configuration["PassSettings"]);
                }
            }

            if (!result.Succeeded) throw new ApplicationException("Falha ao cadastrar o usuário!");
        }

        public async Task<string> Login(LoginStudentDto dto)
        {
            var result = await _signInManagerUser.PasswordSignInAsync(dto.Username, dto.Password, false, false);

            if (!result.Succeeded) throw new ApplicationException("Usuario não autenticado!");

            var user = _signInManagerUser
                .UserManager
                .Users
                .FirstOrDefault(user => user.NormalizedUserName == dto.Username.ToUpper());

            var token = _tokenService.GenerateToken(user);

            return token;
        }
    }
}
