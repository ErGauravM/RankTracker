using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using RankTrackerInfrastructure;


namespace RankTrackerServices.Controllers
{
    [Route("api/[controller]")]
    public class RankTrackerController : Controller
    {
        private IDownLoader downloader;
        private IParser parser;
        private readonly string searchEngineUrl = "http://google.com/";
        private readonly string pageSize = "100";

        public RankTrackerController(IDownLoader downLoader, IParser parser)
        {
            this.downloader = downLoader;
            this.parser = parser;
        }

        [HttpGet]
        public async Task<JsonResult> TrackRankAsync(string keyWords, string Url)
        {           
            string content = await downloader.DownLoadContent(searchEngineUrl, keyWords, pageSize);
            string html = Common.SanitizeHtml(content);
            return Json(parser.ParseAndSearch(html, Url));
        }

    }
}