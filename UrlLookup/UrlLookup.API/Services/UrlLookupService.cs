using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlLookup.API.Data;
using UrlLookup.API.Models;

namespace UrlLookup.API.Services
{

    public class UrlLookupService : IUrlLookupService
    {
        private readonly IUrlInfoDatabase _database;

        public UrlLookupService(IUrlInfoDatabase database)
        {
            _database = database;
        }

        public UrlInfo FindUrl(string request)
        {
            if (request == null)
            {
                return null;
            }

            UrlInfo urlInfo = _database.ReadByUrlRequest(request);
            
            return urlInfo;
        }
    }
}
