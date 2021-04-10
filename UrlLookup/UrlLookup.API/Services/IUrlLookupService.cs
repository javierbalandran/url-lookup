using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlLookup.API.Models;

namespace UrlLookup.API.Services
{
    public interface IUrlLookupService
    {
        UrlInfo FindUrl(UrlInfoRequest request);
    }
}
