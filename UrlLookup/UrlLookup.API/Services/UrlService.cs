using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlLookup.API.Models;

namespace UrlLookup.API.Services
{
    public class UrlService
    {
        private readonly IMongoCollection<Url> _urls;

        public UrlService(IMaliciousUrlsDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _urls = database.GetCollection<Url>(settings.UrlsCollectionName);
        }

        public List<Url> Get() => _urls.Find(book => true).ToList();

        public Url Get(string id) => _urls.Find<Url>(url => url.Id == id).FirstOrDefault();

        public Url Create(Url url)
        {
            _urls.InsertOne(url);
            return url;
        }

        public void Update(string id, Url urlIn) => _urls.ReplaceOne<Url>(url => url.Id == id, urlIn);

        public void Remove(Url urlOut) => _urls.DeleteOne(url => url.Id == urlOut.Id);

        public void Remove(string id) => _urls.DeleteOne(url => url.Id == id);
    }
}
