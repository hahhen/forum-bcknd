using CpsForum.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UsuariosApi.Models;

namespace UsuariosApi.Data
{
    public class UsuarioDbContext : IdentityDbContext<IdentityUser>
    {
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> opts)
            : base(opts)
        {

        }
    }
}
