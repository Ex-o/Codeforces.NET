using cfapi.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace cfapi.Methods
{
    public abstract class RequestBase<TObject>
    {
        protected RequestBase()
        {

        }
        /// <summary>
        /// Sends API Request.
        /// </summary>
        /// <param name="url">Api Request URL</param>
        /// <returns>T: Requested object.</returns>
        protected virtual async Task<ApiResponse<TObject>> GetAsync(string url)
        {
            try
            {
                using (var webClient = new HttpClient())
                {
                    var apiData = await webClient.GetStringAsync(url);
                    return Deserialize(HttpUtility.HtmlDecode(apiData));
                }
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Deserializes API data into JSON.
        /// </summary>
        /// <param name="apiData"></param>
        /// <returns>A List<list type="T">Object requested</list></returns>
        private ApiResponse<TObject> Deserialize(string apiData)
        {
            /*
             * Work around to have consistent ApiResponse<T>
             */

            var index = apiData.IndexOf("result\":");
            if (apiData.Substring(index + 8, 1) != "[")
            {
                apiData = apiData.Insert(apiData.IndexOf("result\":") + 8, "[");
                apiData = apiData.Insert(apiData.LastIndexOf("}"), "]");
            }

            return JsonConvert.DeserializeObject<ApiResponse<TObject>>(apiData);
        }
    }
}