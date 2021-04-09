using UrlLookup.API.Models;

namespace UrlLookup.API.Services
{
    public interface IUrlInfoService
    {
        public UrlInfo Add(UrlInfo urlInfo);
        public void Delete(string id);
        public void Delete(UrlInfo urlOut);
        public UrlInfo Get(string id);
        public UrlInfo Get(string hostNameAndPort, string pathAndQuery);
        public void Update(string id, UrlInfo urlIn);
    }
}