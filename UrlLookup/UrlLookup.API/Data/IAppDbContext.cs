using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlLookup.API.Models;

namespace UrlLookup.API.Data
{
    interface IAppDbContext
    {
        public UrlInfo CreateUrlInfo(UrlInfo urlInfo);
        public UrlInfo ReadUrlInfo(string id);
        public void UpdateUrlInfo(string id, UrlInfo urlIn);
        public void DeleteUrlInfo(UrlInfo urlOut);
        public void DeleteUrlInfo(string id);
    }
}
