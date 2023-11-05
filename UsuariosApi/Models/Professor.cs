using Microsoft.AspNetCore.Identity;

namespace CpsForum.Models
{
    public class Professor : IdentityUser
    {
        public DateTime DataNascimento { get; set; }

        public Professor() : base() { }
    }
}
