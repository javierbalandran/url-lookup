namespace UrlLookup.API.Models
{
    public interface IMongoDbSettings
    {
        string CollectionName { get; set; }
        string DatabaseName { get; set; }
    }
}