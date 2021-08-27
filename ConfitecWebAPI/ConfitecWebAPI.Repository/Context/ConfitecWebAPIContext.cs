using ConfitecWebAPI.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ConfitecWebAPI.Repository.Context
{
    public class ConfitecWebAPIContext : DbContext
    {
        public DbSet<UsuarioEntity> Usuarios { get; set; }

        public ConfitecWebAPIContext(DbContextOptions<ConfitecWebAPIContext> options) : base(options) { }

        //public ConfitecWebAPIContext(IConfiguration configuration) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string 

        //    optionsBuilder.UseSqlServer("");
        //}
    }
}
