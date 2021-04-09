using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlLookup.API.Models;
using UrlLookup.API.Services;

namespace UrlLookup.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UrlInfoController : ControllerBase
    {
        private readonly IUrlInfoService _urlService;

        public UrlInfoController(UrlInfoService urlService)
        {
            _urlService = urlService;
        }

        [HttpGet("{version:int}/{host}/{*path}")]
        public ActionResult<UrlInfo> Get([FromRoute] FullUrl fullUrl, [FromQuery] Dictionary<string,string> query)
        {
            // Parse Request

            // Validate Request

            // Form Response

            // Send Response

            fullUrl.Query = query;
            
            return Ok(fullUrl);
        }
    }
}
