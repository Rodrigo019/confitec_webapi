using ConfitecWebAPI.Domain.Aggregations.Usuario.Interfaces;
using ConfitecWebAPI.Domain.Interfaces.Mapping;
using ConfitecWebAPI.Repository.Context;
using ConfitecWebAPI.Repository.Mapping;
using ConfitecWebAPI.Repository.Usuario;
using Microsoft.Extensions.DependencyInjection;

namespace ConfitecWebAPI.Ioc
{
    public class ConfigRepositoryIoc
    {
        public static void Config(IServiceCollection services)
        {
            services.AddTransient<IMapConfig, MapConfig>();
            services.AddTransient<ConfitecWebAPIContext>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
        }
    }
}
