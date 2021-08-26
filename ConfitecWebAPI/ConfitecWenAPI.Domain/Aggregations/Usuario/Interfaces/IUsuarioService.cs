using ConfitecWebAPI.Domain.Aggregations.Usuario.Entities;
using ConfitecWebAPI.Domain.Interfaces.Services;

namespace ConfitecWebAPI.Domain.Aggregations.Usuario.Interfaces
{
    public interface IUsuarioService : 
        IServiceCrudBase<UsuarioDomain>
    {
    }
}
