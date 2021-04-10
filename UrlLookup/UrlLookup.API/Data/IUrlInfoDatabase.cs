using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlLookup.API.Models;

namespace UrlLookup.API.Data
{
    public interface IUrlInfoDatabase
    {
        void Create(UrlInfo urlInfo);
        UrlInfo ReadById(string id);
        UrlInfo ReadByUrlRequest(string request);
    }
}
