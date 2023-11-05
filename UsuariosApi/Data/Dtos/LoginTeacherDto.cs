using System.ComponentModel.DataAnnotations;

namespace CpsForum.Data.Dtos
{
    public class LoginTeacherDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
