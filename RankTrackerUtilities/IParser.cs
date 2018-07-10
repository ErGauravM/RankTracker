using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankTrackerInfrastructure
{
    public interface IParser
    {
         string ParseAndSearch(string sanitizedHtml, string url);
    }
}
