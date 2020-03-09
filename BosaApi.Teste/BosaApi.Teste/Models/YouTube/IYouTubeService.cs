using BosaApi.Teste.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BosaApi.Teste.Models
{
    public partial interface IYouTubeService
        : IPublicService
    {
        Task<IActionResult> SearchBdAsync(string researchTerms);

        Task<IActionResult> SearchAsync(string researchTerms);
    }
}
