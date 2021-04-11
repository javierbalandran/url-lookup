using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlLookup.API.Models;
using UrlLookup.API.Services;
using UrlLookup.API.Filters;

namespace UrlLookup.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [ApiKeyAuth]
    public class UrlInfoController : ControllerBase
    {
        private IUrlLookupService _urlLookupService;

        public UrlInfoController(IUrlLookupService service)
        {
            _urlLookupService = service;
        }

        [HttpGet("{version:int}/{host}/{*path}")]
        [HttpGet("{version:int}")]
        [HttpGet()]
        public ActionResult<UrlInfo> Get([FromRoute] UrlInfoRequest request, [FromQuery] Dictionary<string, string> query)
        {
            if (_urlLookupService.isRequestInvalid(request))
            {
                return BadRequest("Ensure the url has the proper version or that the host exists");
            }

            string rawRequest = UriHelper.GetDisplayUrl(Request);
            request = _urlLookupService.formatUrlRequest(request, query, rawRequest);
            string url = _urlLookupService.getUriFromRequest(request);

            UrlInfo response = _urlLookupService.findUrl(url);

            if (response == null)
            {
                return NotFound("Safe");
            }

            return Ok(response);
        }
    }
}
