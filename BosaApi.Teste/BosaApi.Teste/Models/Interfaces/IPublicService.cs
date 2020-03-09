using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BosaApi.Teste.Models.Interfaces
{
    public interface IPublicService
    {
        Task<IActionResult> GetAllAsync();

        Task<IActionResult> GetAsync(int id);
    }
}
