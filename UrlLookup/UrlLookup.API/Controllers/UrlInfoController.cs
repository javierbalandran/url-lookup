using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
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
        private IUrlLookupService _urlLookupService;

        public UrlInfoController(IUrlLookupService service)
        {
            _urlLookupService = service;
        }


        [HttpGet("{version:int}/{host}/{*path}")]
        public ActionResult<UrlInfo> Get([FromRoute] UrlInfoRequest urlInfoRequest, [FromQuery] Dictionary<string,string> query)
        {            
            urlInfoRequest.Query = query;

            return Ok(_urlLookupService.FindUrl(urlInfoRequest));

            // Parse Request

            // Validate Request

            // Form Response

            // Send Response



            //return Ok(fullUrl);
        }
    }
}
