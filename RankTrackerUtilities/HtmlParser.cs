using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;

namespace RankTrackerUtilities
{
    public class HtmlParser : IParser
    {
        private readonly string NoMatchFound = "0";
        /// <summary>
        /// This method will parse html and try to serach the url in the html
        /// Not the best way to to parse html may be we should use the htmlagility pack
        /// </summary>
        /// <param name="sanitizedHtml"></param>
        /// <param name="urlToBeSearched"></param>
        /// <returns></returns>
        public virtual string ParseAndSearch(string sanitizedHtml, string urlToBeSearched)
        {
            IEnumerable<XElement> nextChildDivs = null;
            XElement resultElement = null;
            bool matchFound = false;
            int counter = 1;
            StringBuilder rankString = new StringBuilder();

            System.Xml.Linq.XDocument xd = System.Xml.Linq.XDocument.Parse(sanitizedHtml);

            resultElement = xd.XPathSelectElement("descendant::div[@id='ires']");
            nextChildDivs = xd.XPathSelectElements("descendant::div[@class='g']");

            if (nextChildDivs != null)
            {
                foreach (XElement childNode in nextChildDivs)
                {
                    var siteUrlNode = childNode.Descendants("cite").FirstOrDefault();

                    if (siteUrlNode != null && siteUrlNode.Value.Contains(urlToBeSearched))
                    {
                        if (matchFound)
                            rankString.Append(",");
                        rankString.Append(counter);
                        matchFound = true;
                    }
                    if (siteUrlNode != null)
                        counter++;
                }
            }
            if (!matchFound)
                return NoMatchFound;
            else
                return rankString.ToString();
        }
    }
}
