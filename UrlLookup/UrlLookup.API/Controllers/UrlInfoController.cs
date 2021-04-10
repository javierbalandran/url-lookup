using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Extensions;
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
        public ActionResult<UrlInfo> Get([FromRoute] UrlInfoRequest urlInfoRequest, [FromQuery] Dictionary<string, string> query)
        {
            // Parse Request
            urlInfoRequest.Query = query;
            urlInfoRequest.RawRequest = UriHelper.GetDisplayUrl(Request);

            // Validate Request

            // Form Response
            UrlInfo response = _urlLookupService.FindUrl(urlInfoRequest);

            // Send Response
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}
