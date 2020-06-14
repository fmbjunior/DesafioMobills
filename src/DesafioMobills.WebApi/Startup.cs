using DesafioMobills.WebApi.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.OpenApi.Models;
using DesafioMobills.WebApi.Negocio;

namespace DesafioMobills.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<DespesaNegocio>();
            services.AddTransient<ReceitaNegocio>();
            services.AddTransient<ContaNegocio>();
            services.AddTransient<DespesaRepositorio>();
            services.AddTransient<ReceitaRepositorio>();
            services.AddTransient<ContaRepositorio>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Desafio Mobills",
                        Version = "v1",
                        Description = "API criada com o ASP.NET Core 3.1 para gerenciar contas.",
                        Contact = new OpenApiContact
                        {
                            Name = "Francisco Magalhães",
                            Url = new Uri("https://github.com/fmbjunior")
                        }
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Ativando middlewares para uso do Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Desafio Mobills");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
