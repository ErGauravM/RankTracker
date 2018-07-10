using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using RankTrackerInfrastructure;

namespace RankTrackerTests
{
    [TestClass]
    public class RankTrackerTest
    {
        [TestMethod]
        public void ParseHtml_Pass()
        {
            string dir = Directory.GetCurrentDirectory();
            string fileName = "Response.html";
            string url = "pwc.com";
            string html = string.Empty;          
            string path= Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName+ @"\" + fileName;
            html = File.ReadAllText(path);
            string sanitizedHtml = Common.SanitizeHtml(html);
            HtmlParser parser = new HtmlParser();
            Assert.IsNotNull(parser.ParseAndSearch(sanitizedHtml, url));                               
        }

        [TestMethod]
        public void WebDownLoader_Pass()
        {
            string searchUrl = "http://www.google.com/";
            string keywords = "title search";
            string pageSize = "100";
            IDownLoader downloader = new WebClientDownloader();
            ///keyWords = title search & url = http://www.google.com/
            var Content=downloader.DownLoadContent(searchUrl, keywords, pageSize);
            Assert.AreNotEqual(0,Content.Result.Length);
        }
    }
}
