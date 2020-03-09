using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BosaApi.Teste.Models.Database
{
    public class YouTube
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int _id { get; set; }

        [BsonElement("SearchDsc")]
        public string SearchDsc { get; set; }
    }
}