using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace BosaApi.Teste.Models.Database
{
    public class MongoService
    {
        private readonly IMongoCollection<YouTube> _youtubes;

        public MongoService(IMongoDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _youtubes = database.GetCollection<YouTube>(settings.MongosCollectionName);
        }

        public List<YouTube> Get() =>
            _youtubes.Find(YouTube => true).ToList();

        public YouTube Get(int id) =>
            _youtubes.Find<YouTube>(youTube => youTube._id == id).FirstOrDefault();

        public YouTube Create(YouTube youTube)
        {
            _youtubes.InsertOne(youTube);
            return youTube;
        }

        public void Update(int id, YouTube youTubeIn) =>
            _youtubes.ReplaceOne(youTube => youTube._id == id, youTubeIn);

        public void Remove(YouTube youTubeIn) =>
            _youtubes.DeleteOne(youTube => youTube._id == youTubeIn._id);

        public void Remove(int id) =>
            _youtubes.DeleteOne(youTube => youTube._id == id);
    }
}
