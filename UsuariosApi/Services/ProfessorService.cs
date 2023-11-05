using AutoMapper;
using CpsForum.Data.Dtos;
using CpsForum.Models;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Services;

namespace CpsForum.Services
{
    public class ProfessorService
    {
        private SignInManager<IdentityUser> _signInManagerUser;
        private TokenService _tokenService;
        private SendEmailService _sendEmailService;
        private IConfiguration _configuration;

        public IMapper _mapper { get; set; }
        public UserManager<IdentityUser> _teacherManager { get; set; }

        public ProfessorService(SignInManager<IdentityUser> signInManagerUser, TokenService tokenService, SendEmailService sendEmailService, IConfiguration configuration, IMapper mapper, UserManager<IdentityUser> teacherManager)
        {
            _signInManagerUser = signInManagerUser;
            _tokenService = tokenService;
            _sendEmailService = sendEmailService;
            _configuration = configuration;
            _mapper = mapper;
            _teacherManager = teacherManager;
        }

        public async Task Register(CreateTeacherDto dto)
        {
            Professor prof = _mapper.Map<Professor>(dto);

            IdentityResult result = await _teacherManager.CreateAsync(prof, dto.Password);

            if (result.Succeeded)
            {
                if (dto.Email is not null)
                {
                    await _sendEmailService.ConstructorEmail(dto, _configuration["EmailSettings"], _configuration["PassSettings"]);
                }
            }

            if (!result.Succeeded) throw new ApplicationException("Falha ao cadastrar o usuário!");
        }

        public async Task<string> Login(LoginTeacherDto dto)
        {
            var result = await _signInManagerUser.PasswordSignInAsync(dto.Username, dto.Password, false, false);

            if (!result.Succeeded) throw new ApplicationException("Professor não autenticado!");

            var user = _signInManagerUser
                .UserManager
                .Users
                .FirstOrDefault(prof => prof.NormalizedUserName == dto.Username.ToUpper());

            var token = _tokenService.GenerateToken(user);

            return token;
        }
    }
}
