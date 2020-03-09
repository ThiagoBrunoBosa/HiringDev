using BosaApi.Teste.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Examples;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;

namespace BosaApi.Teste.Initializers
{
    /// <summary>
    /// Configuração do Swagger, responsável para UI da Web Api
    /// </summary>
    public static class SwaggerInit
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider()
                .GetRequiredService<IApiVersionDescriptionProvider>();

            services.AddSwaggerGen(options =>
            {
                // Identificação das versões implementadas

                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(description.GroupName,
                        new Info()
                        {
                            Title = $"YouTube API {description.ApiVersion}",
                            Version = description.ApiVersion.ToString(),
                            Description = "Documentation.",
                            TermsOfService = "None",
                            Contact = new Contact
                            {
                                Name = "Thiago Bruno Bosa",
                                Email = "thiagobrunobosa@gmail.com"
                            }
                        });
                }

                // Para incluir os exemplos na documentação

                options.OperationFilter<ExamplesOperationFilter>();

                // Filter para ocultar o 'lock' da ações não autenticadas.

                options.OperationFilter<AuthorizeCheckOperationFilter>();

                // Filter para adicionar o BadRequest para ações com ModelState

                options.OperationFilter<ValidateModelOperationFilter>();

                // Incluir os comentários do código à documentação

                var xmlCommentsPath = Assembly.GetExecutingAssembly()
                    ?.Location
                    ?.Replace("dll", "xml");

                //if (!string.IsNullOrEmpty(xmlCommentsPath))
                //    options.IncludeXmlComments(xmlCommentsPath);
            });
        }

        public static void ConfigureSwagger
            (this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint(
                        $"./swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant()
                    );

                    options.RoutePrefix = string.Empty;

                    options.DocumentTitle = "YouTube API Documentation";

                    options.DocExpansion(DocExpansion.None);

                    options.InjectStylesheet("./custom.css");
                }
            });
        }
    }
}
