using BosaApi.Teste.Models.Database;
using BosaApi.Teste.Models.Templates;
//using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BosaApi.Teste.Models
{
    public partial class YouTubeRepository
        : PublicRepository<YouTube>, IYouTubeRepository
    {
        private readonly MongoService mongoService;

        public override async Task<YouTube> GetAsync(int id)
        {
            return mongoService.Get(id);
        }

        public override async Task<IEnumerable<YouTube>> GetAllAsync()
        {
            return mongoService.Get();
        }

        public override async Task SaveAsync(YouTube model)
        {
            if (model == null) return;

            mongoService.Create(model);

            return;
        }
    }
}
