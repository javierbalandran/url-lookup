using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlLookup.API.Models;

namespace UrlLookup.API.Services
{
    public interface IUrlLookupService
    {
        UrlInfo findUrl(string request);
        public bool isRequestInvalid(UrlInfoRequest urlInfoRequest);
        public UrlInfoRequest formatUrlRequest(UrlInfoRequest urlInfoRequest, Dictionary<string, string> query, string rawRequest);
        public string getUriFromRequest(UrlInfoRequest request);
    }
}
