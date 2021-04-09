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
    [NonController]
    public class UrlsController : ControllerBase
    {
        private readonly UrlService _urlService;

        public UrlsController(UrlService urlService)
        {
            _urlService = urlService;
        }

        [HttpGet]
        public ActionResult<List<Url>> GetAllUrls()
        {
            var urls = _urlService.Get();

            if (urls == null)
            {
                return NotFound();
            }
            return urls;
        }

        [HttpGet("{id:length(24)}")]
        public ActionResult<Url> GetUrl(string id)
        {
            var url = _urlService.Get(id);

            if (url == null)
            {
                return NotFound();
            }

            return url;
        }
    }
}
