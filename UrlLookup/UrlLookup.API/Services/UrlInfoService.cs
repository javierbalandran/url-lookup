using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlLookup.API.Models;

namespace UrlLookup.API.Services
{
    public class UrlInfoService
    {
        private readonly IMongoCollection<UrlInfo> _urls;

        public UrlInfoService(IMaliciousUrlsDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _urls = database.GetCollection<UrlInfo>(settings.UrlsCollectionName);
        }

        public List<UrlInfo> GetAll() => _urls.Find(book => true).ToList();

        public UrlInfo Get(string id) => _urls.Find<UrlInfo>(url => url.Id == id).FirstOrDefault();

        public UrlInfo Create(UrlInfo url)
        {
            _urls.InsertOne(url);
            return url;
        }

        public void Update(string id, UrlInfo urlIn) => _urls.ReplaceOne<UrlInfo>(url => url.Id == id, urlIn);

        public void Remove(UrlInfo urlOut) => _urls.DeleteOne(url => url.Id == urlOut.Id);

        public void Remove(string id) => _urls.DeleteOne(url => url.Id == id);
    }
}
