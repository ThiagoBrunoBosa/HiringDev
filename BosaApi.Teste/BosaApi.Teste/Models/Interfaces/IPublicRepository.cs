using System.Collections.Generic;
using System.Threading.Tasks;

namespace BosaApi.Teste.Models.Interfaces
{
    public interface IPublicRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetAsync(int id);

        Task SaveAsync(T model);
    }
}
