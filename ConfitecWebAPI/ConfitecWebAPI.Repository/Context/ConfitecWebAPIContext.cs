using ConfitecWebAPI.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConfitecWebAPI.Repository.Context
{
    public class ConfitecWebAPIContext : DbContext
    {
        public DbSet<UsuarioEntity> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
        }
    }
}
