using System.ComponentModel.DataAnnotations;

namespace CpsForum.Data.Dtos
{
    public class CreateTeacherDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string RePassword { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}
