using AutoMapper;
using ConfitecWebAPI.Domain.Aggregations.Usuario.Entities;
using ConfitecWebAPI.Repository.Entities;

namespace ConfitecWebAPI.Repository.Mapping
{
    public class UsuarioMap : Profile
    {
        public UsuarioMap()
        {
            CreateMap<UsuarioEntity, UsuarioDomain>().ReverseMap();
        }
    }
}
