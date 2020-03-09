using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics.CodeAnalysis;

namespace BosaApi.Teste
{
    [SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Using Serilog")]
    public sealed class Program
    {
        public static int Main(string[] args)
        {
            var host = CreateWebHostBuilder(args)
                .Build();

            CreateDbIfNotExists(host);

            try
            {
                host.Run();

                return 0;
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        /// <summary>
        /// Configurei o banco de dados para utilizar um SQLEXPRESS.
        /// Se precisar mudar isso, veja a string de conexão no 'appsettings.json'.
        /// </summary>
        private static void CreateDbIfNotExists(IWebHost host)
        {
            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //
            //    try
            //    {
            //        var context = services
            //            .GetRequiredService<Models.Database.BosaDbContext>();
            //    }
            //    catch (Exception ex)
            //    {
            //        var logger = services
            //            .GetRequiredService<ILogger<Program>>();
            //
            //        logger.LogError(ex, "Error_DatabaseCreate");
            //    }
            //}
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
