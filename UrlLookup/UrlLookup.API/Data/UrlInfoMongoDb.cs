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

        public UrlInfoMongoDb(IMongoClient client, IMongoDbSettings settings)
        {
            var database = client.GetDatabase(settings.DatabaseName);
            _urlListCollection = database.GetCollection<UrlInfo>(settings.CollectionName);
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
            if (request == null)
            {
                return null;
            }

            UrlInfo resultActual = _urlListCollection.Find(s => s.UrlName == request).FirstOrDefault<UrlInfo>();

            return resultActual;
        }
    }
}
