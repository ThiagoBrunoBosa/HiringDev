using BosaApi.Teste.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BosaApi.Teste.Filters
{
    // Ref: @ErrorHandler

    /// <summary>
    /// Filter padrão de tratamento de erros
    /// </summary>
    public class ExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; set; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context?.Exception is HttpResponseException exception)
            {
                context.Result = new ObjectResult(exception.Value)
                {
                    StatusCode = exception.Status,
                };

                context.ExceptionHandled = true;
            }
        }
    }
}
