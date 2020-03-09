using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace BosaApi.Teste.Filters
{
    /// <summary>
    /// Filter para adicionar o BadRequest para ações com ModelState
    /// </summary>
    public class ValidateModelOperationFilter
        : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation?.Responses == null
                || operation?.Parameters == null)
                return;

            if (operation.Parameters.Any())
                operation.Responses.Add("400",
                    new Response
                    {
                        Description = "Bad request"
                    });

            operation.Responses.Add("409",
                new Response
                {
                    Description = "Conflict"
                });

            operation.Responses.Add("404",
                new Response
                {
                    Description = "Not Found"
                });
        }
    }
}
