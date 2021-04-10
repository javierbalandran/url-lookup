﻿using System.Collections.Generic;

namespace UrlLookup.API.Models
{
    public class UrlInfoRequest
    {
        public int Version { get; set; }
        public string Host { get; set; }
        public string Path { get; set; }
        public Dictionary<string, string> Query { get; set; }

        public string FormattedRequest { 
            get
            {
                return Host;
            }
        }

        private string formatRequest(string host, string path, Dictionary<string, string> query)
        {

            return host;
        }

    }
}
