using AutoMapper;
using CpsForum.Data.Dtos;
using CpsForum.Models;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Models;

namespace CpsForum.Profiles
{
    public class ProfessorProfile : Profile
    {
        public ProfessorProfile()
        {
            CreateMap<CreateTeacherDto, Professor>();
        }
    }
}
