using BosaApi.Teste.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
//using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BosaApi.Teste.Initializers
{
    public static class ServiceInit
    {
        public static void ConfigureService
            (this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<BosaDbContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("BosaDatabase"))
            //);

            // A chamada a este Filter aqui, permite que ele também utilize o AccountScope

            // services.AddScoped<AccountTicketBinderFilter>();

            // Inicializadores dos serviços e repositórios da aplicação

            YouTubeScope.Bind(services);
        }

        public static void ConfigureErrorHandler
            (this IApplicationBuilder app, IHostingEnvironment env)
        {
            // Ref: @ErrorHandler

            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/error-local-development");
            }
            else
            {
                app.UseExceptionHandler("/error");
            }
        }
    }
}
