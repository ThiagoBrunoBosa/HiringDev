using BosaApi.Teste.Controllers.Templates;
using BosaApi.Teste.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Examples;
using System.Threading.Tasks;

namespace BosaApi.Teste.Controllers
{
    /// <summary>
    /// Métodos de pesquisa e retorno
    /// </summary>
    [Route("/api/v{version:apiVersion}[controller]/")]
    [ApiController]
    public class YouTubeController
        : ControllerServiceBase<IYouTubeService>
    {
        public YouTubeController
            (IYouTubeService service)
            : base(service) { }

        /// <summary>
        /// Recuperar todos itens do banco de dados
        /// </summary>
        /// <returns>itens desejados</returns>
        [HttpGet("ComBancoDeDados")]
        [ProducesResponseType(typeof(YouTubeResponse), StatusCodes.Status200OK)]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(GetAllResponse))]
        public async Task<IActionResult> GetAll()
        {
            return await RepositoryService.GetAllAsync();
        }

        /// <summary>
        /// Recuperar um item do banco de dados
        /// </summary>
        /// <param name="id">Código do item desejado</param>
        /// <returns>Item desejado</returns>
        [HttpGet("ComBancoDeDados/{id}")]
        [ProducesResponseType(typeof(YouTubeResponse), StatusCodes.Status200OK)]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(GetResponse))]
        public async Task<IActionResult> GetItem(int id)
        {
            return await RepositoryService.GetAsync(id);
        }

        /// <summary>
        /// Retorna os dez primeiros resultados de vídeos da api do youtube (sem banco de dados)
        /// </summary>
        /// <param name="researchTerm">Termos de pesquisa</param>
        /// <returns>10 primeiros vídeos do termo pesquisado salvando no banco de dados</returns>
        [HttpGet("ComBancoDeDados/{researchTerm}")]
        public async Task<IActionResult> SearchWithBd(string researchTerm)
        {
            return await RepositoryService.SearchBdAsync(researchTerm);
        }

        /// <summary>
        /// Retorna dez primeiros resultados de vídeos da api do youtube (sem banco de dados)
        /// </summary>
        /// <param name="researchTerm">Termos de pesquisa</param>
        /// <returns>10 primeiros vídeos do termo pesquisado</returns>
        [HttpGet("SemBancoDeDados/{researchTerm}")]
        public async Task<IActionResult> Search(string researchTerm)
        {
            return await RepositoryService.SearchAsync(researchTerm);
        }

        #region Examples

        private class GetAllResponse : IExamplesProvider
        {
            public object GetExamples()
            {
                return new[]
                {
                    new YouTubeResponse
                    {
                        Id = "1",
                        SearchDsc = "YouTube A"
                    },
                    new YouTubeResponse
                    {
                        Id = "2",
                        SearchDsc = "YouTube B"
                    }
                };
            }
        }

        private class GetResponse : IExamplesProvider
        {
            public object GetExamples()
            {
                return new YouTubeResponse
                {
                    Id = "1",
                    SearchDsc = "YouTube A"
                };
            }
        }

        #endregion
    }
}
