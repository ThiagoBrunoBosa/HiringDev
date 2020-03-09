using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BosaApi.Teste.Controllers.Templates
{
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public abstract class ControllerDefaultBase : ControllerBase
    {
    }
}