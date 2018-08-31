using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using cfapi.Objects;
using Newtonsoft.Json;

namespace cfapi.Methods
{
    public class Request<TObject> : RequestBase<TObject> where TObject : IApiObject, new()
    {
        protected string ApiData(string url)
        {
            try
            {
                using (var webClient = new WebClient { Encoding = Encoding.UTF8 })
                {
                    return HttpUtility.HtmlDecode(webClient.DownloadString(url));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return "";
            }
        }

        public TObject Deserialize(string apiData)
        {
            return JsonConvert.DeserializeObject<TObject>(apiData);
        }
    }
}
