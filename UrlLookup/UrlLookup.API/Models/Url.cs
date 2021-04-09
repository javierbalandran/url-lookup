using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlLookup.API.Models
{
    public class Url
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("date_added")]
        public DateTime DateAdded { get; set; }
        [BsonElement("url_name")]
        [JsonProperty("url_name")]
        public string UrlName { get; set; }
    }
}
