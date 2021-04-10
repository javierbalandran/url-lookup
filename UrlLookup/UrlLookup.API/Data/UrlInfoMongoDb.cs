using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlLookup.API.Models;

namespace UrlLookup.API.Data
{
    public class UrlInfoMongoDb : IUrlInfoDatabase
    {
        private IMongoCollection<UrlInfo> _urlListCollection;

        public UrlInfoMongoDb(IMongoClient client)
        {
            var database = client.GetDatabase("malicious_urls_db");
            _urlListCollection = database.GetCollection<UrlInfo>("url_list");
        }

        public void Create(UrlInfo urlInfo)
        {
            throw new NotImplementedException();
        }

        public UrlInfo ReadById(string id)
        {
            throw new NotImplementedException();
        }

        public UrlInfo ReadByUrlRequest(string request)
        {
            UrlInfo resultActual = _urlListCollection.Find(s => s.UrlName == request).FirstOrDefault<UrlInfo>();

            return resultActual;
        }
    }
}
