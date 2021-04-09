using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlLookup.API.Models
{
    public interface IMaliciousUrlsDatabaseSettings
    {
        public string UrlsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public class MaliciousUrlsDatabaseSettings : IMaliciousUrlsDatabaseSettings
    {
        public string UrlsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
