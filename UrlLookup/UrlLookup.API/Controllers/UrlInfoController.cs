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
        private readonly UrlInfoService _urlService;

        public UrlInfoController(UrlInfoService urlService)
        {
            _urlService = urlService;
        }

        [HttpGet]
        public ActionResult<List<UrlInfo>> GetAllUrls()
        {
            var urls = _urlService.GetAll();

            if (urls == null)
            {
                return NotFound();
            }
            return urls;
        }

        [HttpGet("{id:length(24)}")]
        public ActionResult<UrlInfo> GetUrl(string id)
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
