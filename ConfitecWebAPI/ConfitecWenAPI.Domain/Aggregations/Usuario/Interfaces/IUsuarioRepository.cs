using ConfitecWebAPI.Domain.Aggregations.Usuario.Entities;
using ConfitecWebAPI.Domain.Interfaces.Repositories;

namespace ConfitecWebAPI.Domain.Aggregations.Usuario.Interfaces
{
    public interface IUsuarioRepository :
        IRepositoryCrudBase<UsuarioDomain>,
        IRepositoryInsert<UsuarioDomain>
    {
    }
}
