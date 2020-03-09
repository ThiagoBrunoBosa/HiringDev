using BosaApi.Teste.Models.Interfaces;
using BosaApi.Teste.Useful;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BosaApi.Teste.Models.Templates
{
    [SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Using Serilog")]
    public abstract class PublicService<TModel, TResponse>
        : Service<IPublicRepository<TModel>>, IPublicService
        where TModel : class
        where TResponse : class
    {
        public PublicService(IPublicRepository<TModel> repository, AppSettings appSettings)
            : base(repository, appSettings) { }

        public virtual async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var items = await Repository.GetAllAsync();

                if (items != null)
                {
                    return new OkObjectResult(items.Select(Parse));
                }
                else
                {
                    return new NotFoundResult();
                }
            }
            catch (Exception ex)
            {
                return new ConflictObjectResult(State);
            }
        }

        public virtual async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                var item = await Repository.GetAsync(id);

                if (item != null)
                {
                    return new OkObjectResult(Parse(item));
                }
                else
                {
                    return new NotFoundResult();
                }
            }
            catch (Exception ex)
            {
                return new ConflictObjectResult(State);
            }
        }

        protected virtual TResponse Parse(TModel model)
        {
            throw new NotImplementedException();
        }
    }
}
