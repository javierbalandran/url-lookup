using System.Collections.Generic;

namespace UrlLookup.API.Controllers
{
    public class FullUrl
    {
        public int Version { get; set; }
        public string Host { get; set; }
        public string Path { get; set; }
        public Dictionary<string, string> Query { get; set; }
    }


}
