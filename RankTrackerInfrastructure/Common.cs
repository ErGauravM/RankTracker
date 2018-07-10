using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using RankTrackerUtilities;

namespace RankTrackerInfrastructure
{
    public static class Common
    {

        public static string SanitizeHtml(string html)
        {
            if (string.IsNullOrEmpty(html))
                throw new ArgumentNullException("html");
            html = html.Trim();
            var start = html.IndexOf("<body", StringComparison.OrdinalIgnoreCase);
            var end = html.IndexOf("</body>", start, StringComparison.OrdinalIgnoreCase);
            html = html.Substring(start, (end - start) + 8);
            //get rid of all scripts and style tags
            html = Regex.Replace(html, "(<style.+?</style>)|(<script.+?</script>)|(<br>)|(<img.+?>)", string.Empty, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            //get rid of the  html comments
            html = Regex.Replace(html, "<!--.+?-->", "", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            start = html.IndexOf("<tbody", StringComparison.OrdinalIgnoreCase);
            end = html.IndexOf("</tbody>", start, StringComparison.OrdinalIgnoreCase);
            html = html.Substring(start, (end - start) + 8);
            html = html.Replace("&", "&amp;");         
            return html;
        }

    }
}
