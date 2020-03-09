using Microsoft.Extensions.DependencyInjection;

namespace BosaApi.Teste.Models
{
    public static class YouTubeScope
    {
        public static void Bind(IServiceCollection services)
        {
            services.AddScoped<IYouTubeService, YouTubesService>();

            services.AddScoped<IYouTubeRepository, YouTubeRepository>();
        }


    }
}
