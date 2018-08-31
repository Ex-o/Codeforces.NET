using System;
using System.Net;
using System.Text;
using System.Web;

namespace cfapi
{
    public class Utlitiy
    {
        public static string DownloadString(string url)
        {
            try
            {
                var webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                return HttpUtility.HtmlDecode(webClient.DownloadString(url));
            }
            catch (Exception e)
            {
                return "";
            }
        }
    }
}