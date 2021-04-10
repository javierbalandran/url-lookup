using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlLookup.API.Models
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
    }
}
