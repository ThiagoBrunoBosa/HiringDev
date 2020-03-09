using BosaApi.Teste.Models.Database;
using BosaApi.Teste.Models.Templates;
using BosaApi.Teste.Useful;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BosaApi.Teste.Models
{
    public partial class YouTubesService
        : PublicService<YouTube, YouTubeResponse>, IYouTubeService
    {
        public YouTubesService(IYouTubeRepository repository, AppSettings appSettings)
            : base(repository, appSettings) { }

        protected override YouTubeResponse Parse(YouTube model)
        {
            if (model == null) return null;

            return new YouTubeResponse
            {
                SearchDsc = model.SearchDsc
            };
        }

        public virtual async Task<IActionResult> SearchBdAsync(string researchTerms)
        {
            try
            {
                var itens = await YoutubeHelper.YoutubeSearch(researchTerms);

                if (itens != null)
                {
                    foreach (var item in itens)
                    {
                        var youtube = new YouTube
                        {
                            SearchDsc = item
                        };

                        await Repository.SaveAsync(youtube);
                    }

                    return new OkObjectResult(itens);
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

        public virtual async Task<IActionResult> SearchAsync(string researchTerms)
        {
            try
            {
                var itens = await YoutubeHelper.YoutubeSearch(researchTerms);

                if (itens != null)
                {
                    return new OkObjectResult(itens);
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
    }
}
