using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlLookup.API.Data;
using UrlLookup.API.Models;

namespace UrlLookup.API.Services
{
    public class UrlInfoService : IUrlInfoService
    {
        private readonly IAppDbContext _dbContext;

        public UrlInfoService(IDatabaseSettings settings)
        {
            _dbContext = new MongoDbContext(settings);
        }

        public UrlInfo Add(UrlInfo urlInfo) => _dbContext.CreateUrlInfo(urlInfo);
        public UrlInfo Get(string id) => _dbContext.ReadUrlInfo(id);
        public UrlInfo Get(string hostNameAndPort, string pathAndQuery) => _dbContext.ReadUrlInfo(hostNameAndPort, pathAndQuery);
        public void Update(string id, UrlInfo urlIn) => _dbContext.UpdateUrlInfo(id, urlIn);
        public void Delete(UrlInfo urlOut) => _dbContext.DeleteUrlInfo(urlOut);
        public void Delete(string id) => _dbContext.DeleteUrlInfo(id);
    }
}
