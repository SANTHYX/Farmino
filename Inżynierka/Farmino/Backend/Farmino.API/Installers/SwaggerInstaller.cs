using Farmino.API.Installers.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Farmino.API.Installers
{
    public class SwaggerInstaller : IInstaler
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("Farmino", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Farmino",
                    Description = "Simple auction app using ASP.NET Core 3.1 + Vue",
                    Contact = new OpenApiContact
                    {
                        Name = "Damian Dorocicz",
                    }
                });
            });
        }
    }
}
