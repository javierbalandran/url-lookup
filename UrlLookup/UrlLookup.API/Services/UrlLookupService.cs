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

        public UrlInfo FindUrl(UrlInfoRequest request)
        {
            UrlInfo result = _database.ReadByUrlRequest("this/is/not/true");
            return result;
        }
    }
}
