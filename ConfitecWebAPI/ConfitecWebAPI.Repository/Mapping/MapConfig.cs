using AutoMapper;
using ConfitecWebAPI.Domain.Interfaces.Mapping;

namespace ConfitecWebAPI.Repository.Mapping
{
    public class MapConfig : IMapConfig
    {
        public IMapper Mapper { get; private set; }

        public MapConfig()
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.AddProfile<UsuarioMap>();
            });

            Mapper = configuration.CreateMapper();
        }

        public T Map<T>(object data)
        {
            return Mapper.Map<T>(data);
        }

        public Tout Map<Tin, Tout>(Tin data)
        {
            return Mapper.Map<Tin, Tout>(data);
        }
    }
}
