using ConfitecWebAPI.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConfitecWebAPI.Repository.Context
{
    public class ConfitecWebAPIContext : DbContext
    {
        public DbSet<UsuarioEntity> Usuarios { get; set; }

        public ConfitecWebAPIContext(DbContextOptions<ConfitecWebAPIContext> options) : base(options) { }
    }
}
