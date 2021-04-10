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
        private const string GET_NAME = "urlinfo/";

        public UrlLookupService(IUrlInfoDatabase database)
        {
            _database = database;
        }

        public UrlInfo FindUrl(UrlInfoRequest request)
        {
            string urlToSearch = GetUriFromRequest(request);
            UrlInfo urlInfo = _database.ReadByUrlRequest(urlToSearch);
            
            return urlInfo;
        }

        private string GetUriFromRequest(UrlInfoRequest request)
        {
            string removalString = GET_NAME + request.Version + "/";
            int indexOfGet = request.RawRequest.IndexOf(removalString);
            string uri = request.RawRequest.Substring(indexOfGet + removalString.Length);

            return uri;
        }
    }
}
