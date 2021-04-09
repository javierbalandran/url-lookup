using System.Collections.Generic;

namespace UrlLookup.API.Controllers
{
    public class FullUrl
    {
        public string Version { get; set; }
        public Host Host { get; set; }
        public string Path { get; set; }
        public Dictionary<string, string> Query { get; set; }
    }


}
