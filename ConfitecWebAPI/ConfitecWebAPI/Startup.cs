using ConfitecWebAPI.Ioc;
using ConfitecWebAPI.Repository.Context;
using ConfitecWebAPI.Repository.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConfitecWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //services.AddTransient<IConfiguration>();

            ConfigServiceIoc.Config(services);
            ConfigRepositoryIoc.Config(services);

            services.AddDbContext<ConfitecWebAPIContext>(opt => opt.UseInMemoryDatabase());
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, System.IServiceProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var context = provider.GetService<ConfitecWebAPIContext>();
            AdicionarDadosTeste(context);

            app.UseMvc();
        }

        void AdicionarDadosTeste(ConfitecWebAPIContext ctx)
        {
            var usuario = new UsuarioEntity
            {
                Nome = "Rodrigo",
                Sobrenome = "Otávio Belo",
                Email = "rodrigootavio019@gmail.com",
                DataNascimento = new System.DateTime(1992, 10, 19),
                Escolaridade = 3
            };

            var usuario2 = new UsuarioEntity
            {
                Nome = "João",
                Sobrenome = "dos Santos",
                Email = "joaodossantos@gmail.com",
                DataNascimento = new System.DateTime(2000, 11, 20),
                Escolaridade = 1
            };

            var usuario3 = new UsuarioEntity
            {
                Nome = "Carlos",
                Sobrenome = "Martins",
                Email = "carlosmartins@gmail.com",
                DataNascimento = new System.DateTime(1970, 2, 6),
                Escolaridade = 1
            };

            ctx.Usuarios.Add(usuario);
            ctx.Usuarios.Add(usuario2);
            ctx.Usuarios.Add(usuario3);
            ctx.SaveChanges();
        }
    }
}
