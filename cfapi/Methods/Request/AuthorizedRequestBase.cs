using cfapi.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using cfapi.Helpers;

namespace cfapi.Methods.Request
{
    /// <summary>
    /// Authorized API Request.
    /// https://codeforces.com/settings/api
    /// </summary>
    /// <typeparam name="TObject"></typeparam>
    public class AuthorizedRequestBase<TObject> : RequestBase<TObject>
    {
        private readonly SecurityToken _token;
        public AuthorizedRequestBase(SecurityToken token)
        {
            this._token = token;
        }
        /// <summary>
        /// Downloads API data.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        protected override async Task<ApiResponse<TObject>> GetAsync(string url)
        {
            var args = url.Replace("http://codeforces.com/api/", "");
            var req = url + CodeforcesHelper.GenerateSignature(args, _token);
            Console.WriteLine(req);
            return await base.GetAsync(req);
        }
        
    }
}
