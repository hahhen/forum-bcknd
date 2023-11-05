using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Dtos
{
    public class LoginStudentDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
