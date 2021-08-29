using ConfitecWebAPI.Ioc;
using ConfitecWebAPI.Repository.Context;
using ConfitecWebAPI.Repository.Usuario;
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

            //Adicionando dados iniciais para teste
            var context = provider.GetService<ConfitecWebAPIContext>();
            AdicionarUsuariosTeste.Adicionar(context);            

            app.UseCors(x =>
                x.AllowAnyMethod()
                .AllowAnyHeader()
                .AllowAnyOrigin());

            app.UseHttpsRedirection();

            app.UseMvc();
        }
    }
}
