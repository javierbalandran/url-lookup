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
        [HttpGet("{version:int}")]
        [HttpGet()]
        public ActionResult<UrlInfo> Get([FromRoute] UrlInfoRequest urlInfoRequest, [FromQuery] Dictionary<string, string> query)
        {
            if (isRequestInValid(urlInfoRequest))
            {
                return NotFound("Ensure the url has the proper version or that the host exists");
            }

            urlInfoRequest = formatUrlRequest(urlInfoRequest, query);
            UrlInfo response = _urlLookupService.FindUrl(getUriFromRequest(urlInfoRequest));

            if (response == null)
            {
                return NotFound("Safe");
            }

            return Ok(response);
        }

        private bool isRequestInValid(UrlInfoRequest urlInfoRequest)
        {
            return (urlInfoRequest.Version != 1 || urlInfoRequest.Host == null) ? true : false;
        }

        private UrlInfoRequest formatUrlRequest(UrlInfoRequest urlInfoRequest, Dictionary<string,string> query)
        {
            urlInfoRequest.Query = query;
            urlInfoRequest.RawRequest = UriHelper.GetDisplayUrl(Request);

            return urlInfoRequest;
        }

        private string getUriFromRequest(UrlInfoRequest request)
        {
            string removalString = "urlinfo/" + request.Version + "/";
            int indexOfGet = request.RawRequest.IndexOf(removalString);
            string uri = request.RawRequest.Substring(indexOfGet + removalString.Length);

            return uri;
        }
    }
}
