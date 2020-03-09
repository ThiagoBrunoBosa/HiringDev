using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BosaApi.Teste.Filters
{
    // Ref: @ValidateModel

    /// <summary>
    /// Filter padrão de tratamento de Request
    /// </summary>
    public class ValidateModelFilterAttribute
        : ActionFilterAttribute
    {
        public override void OnActionExecuting
            (ActionExecutingContext context)
        {
            if (context?.ModelState?.IsValid == false)
                context.Result =
                    new BadRequestObjectResult(context.ModelState);
        }
    }
}
