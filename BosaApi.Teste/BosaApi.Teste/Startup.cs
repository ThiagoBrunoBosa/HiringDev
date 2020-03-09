using BosaApi.Teste.Initializers;
using BosaApi.Teste.Models;
using BosaApi.Teste.Models.Database;
using BosaApi.Teste.Useful;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BosaApi.Teste
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;

            var _configurationAppSettings = _configuration?.GetSection("AppSettings");

            _appSettings = _configurationAppSettings?.Get<AppSettings>();
        }

        private readonly IConfiguration _configuration;

        private readonly AppSettings _appSettings;

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureCompression();

            services.ConfigureMvc(_appSettings);

            services.ConfigureApi();

            services.ConfigureSwagger();

            services.ConfigureService(_configuration);

            services.AddSingleton(_appSettings);

            services.AddSingleton<MongoService>();

            services.Configure<MongoDatabaseSettings>(
        _configuration.GetSection(nameof(MongoDatabaseSettings)));

            services.AddSingleton<IMongoDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<MongoDatabaseSettings>>().Value);

            //services.AddControllers();
            //.AddNewtonsoftJson(options => options.UseMemberCasing()); 
        }

        public static void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            IApiVersionDescriptionProvider provider
            )
        {
            app.UseStaticFiles();

            app.ConfigureCompression();

            app.ConfigureErrorHandler(env);

            app.ConfigureSwagger(provider);

            app.ConfigureApi();

            app.ConfigureMvc();
        }
    }
}
