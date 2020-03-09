namespace BosaApi.Teste.Models
{
    public class MongoDatabaseSettings : IMongoDatabaseSettings
    {
        public string MongosCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IMongoDatabaseSettings
    {
        string MongosCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
