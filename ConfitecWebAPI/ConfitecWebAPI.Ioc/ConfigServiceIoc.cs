using ConfitecWebAPI.Domain.Aggregations.Usuario.Entities;
using ConfitecWebAPI.Domain.Aggregations.Usuario.Interfaces;
using ConfitecWebAPI.Domain.Interfaces.Services;
using ConfitecWebAPI.Service.Usuario;
using Microsoft.Extensions.DependencyInjection;

namespace ConfitecWebAPI.Ioc
{
    public static class ConfigServiceIoc
    {
        public static void Config(IServiceCollection services)
        {
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IServiceCrudBase<UsuarioDomain>, UsuarioService>();
        }
    }
}
