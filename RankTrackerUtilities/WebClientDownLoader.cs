using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RankTrackerInfrastructure
{
    public class WebClientDownloader : IDownLoader
    {
        
        /// <summary>
        /// This method will help to download the content from web
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="keyWords"></param>
        /// <returns></returns>
        public async Task<string> DownLoadContent(string Url, string keyWords,string pageSize)
        {
            HttpClient hc = new HttpClient();
            byte[] bytes = Encoding.Default.GetBytes(keyWords);
            string search = Encoding.UTF8.GetString(bytes);
            HttpResponseMessage result = await hc.GetAsync($"{Url}/search?q={search}&num={pageSize}");
            return await result.Content.ReadAsStringAsync();
        }
    }
}
