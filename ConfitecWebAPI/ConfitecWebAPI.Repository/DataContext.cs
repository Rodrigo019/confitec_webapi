using ConfitecWebAPI.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConfitecWebAPI.Repository
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            
        }

        public DbSet<UsuarioEntity> Usuarios { get; set; }
    }
}
