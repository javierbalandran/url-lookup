using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlLookup.API.Models;

namespace UrlLookup.API.Data
{
    public class MongoDbContext : IAppDbContext
    {
        private readonly IMongoCollection<UrlInfo> _urlInfos;
        public MongoDbContext(IMaliciousUrlsDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _urlInfos = database.GetCollection<UrlInfo>(settings.UrlsCollectionName);
        }

        // Create
        public UrlInfo CreateUrlInfo(UrlInfo urlInfo)
        {
            _urlInfos.InsertOne(urlInfo);
            return urlInfo;
        }

        // Read
        public UrlInfo ReadUrlInfo(string id) => _urlInfos.Find<UrlInfo>(urlInfo => urlInfo.Id == id).FirstOrDefault();
        public UrlInfo ReadUrlInfo(string hostNameAndPort, string pathAndQuery)
        {
            return _urlInfos.Find<UrlInfo>(urlInfo => urlInfo.UrlName.Contains(hostNameAndPort) & urlInfo.UrlName.Contains(pathAndQuery)).FirstOrDefault();
        }

        // Update
        public void UpdateUrlInfo(string id, UrlInfo urlIn) => _urlInfos.ReplaceOne<UrlInfo>(url => url.Id == id, urlIn);

        // Delete
        public void DeleteUrlInfo(UrlInfo urlOut) => _urlInfos.DeleteOne(url => url.Id == urlOut.Id);

        public void DeleteUrlInfo(string id) => _urlInfos.DeleteOne(url => url.Id == id);
    }
}
