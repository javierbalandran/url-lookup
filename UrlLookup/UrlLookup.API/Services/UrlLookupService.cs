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

        public UrlInfo findUrl(string url)
        {
            if (url == null)
            {
                return null;
            }

            try
            {
                UrlInfo urlInfo = _database.ReadByUrlRequest(url);
                return urlInfo;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool isRequestInvalid(UrlInfoRequest request)
        {
            return (request.Version != 1 || request.Host == null || request.Host == "") ? true : false;
        }

        public UrlInfoRequest formatUrlRequest(UrlInfoRequest request, Dictionary<string, string> query, string rawRequest)
        {
            request.Query = query;
            request.RawRequest = rawRequest;

            return request;
        }

        public string getUriFromRequest(UrlInfoRequest request)
        {
            string removalString = "urlinfo/" + request.Version + "/";
            int indexOfGet = request.RawRequest.IndexOf(removalString);
            string uri = request.RawRequest.Substring(indexOfGet + removalString.Length);

            return uri;
        }
    }
}
