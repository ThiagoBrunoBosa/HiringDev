using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BosaApi.Teste.Filters
{
    /// <summary>
    /// Filter para ocultar o 'lock' da ações não autenticadas.
    /// </summary>
    public class AuthorizeCheckOperationFilter
        : IOperationFilter
    {

        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation?.Responses == null
                || context?.MethodInfo == null)
                return;

            var authAttributes = context.MethodInfo.DeclaringType
                .GetCustomAttributes(true)
                .Union(context.MethodInfo.GetCustomAttributes(true))
                .OfType<AuthorizeAttribute>();

            if (authAttributes.Any())
            {
                operation.Responses.Add("401",
                    new Response { Description = "Unauthorized" });

                operation.Responses.Add("403",
                    new Response { Description = "Forbidden" });


                //// Removido para apresentar no cabeçalho do Swagger

                //if (operation.Parameters == null)
                //    operation.Parameters = new List<IParameter>();

                //operation.Parameters.Add(new NonBodyParameter
                //{
                //    In = "header",
                //    Description = "Inform 'Bearer + token'",
                //    Name = "Authorization",
                //    Type = "apiKey",
                //});

                operation.Security = new List<IDictionary<string, IEnumerable<string>>>
                {
                    new Dictionary<string, IEnumerable<string>>
                    {
                        {"Bearer", Array.Empty<string>()},
                    }
                };
            }
        }
    }
}
