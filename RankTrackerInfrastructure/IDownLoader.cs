using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankTrackerUtilities
{
    public interface IDownLoader
    {
        Task<string> DownLoadContent(string Url, string keyWords, string pageSize);
    }
}
