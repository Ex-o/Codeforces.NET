using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cfapi.Methods.Request;
using cfapi.Objects;

namespace cfapi.Methods
{
    public class UserFriendsRequest : AuthorizedRequestBase<string>
    {
        public UserFriendsRequest(SecurityToken token) : base(token)
        { }

        /// <summary>
        /// Requests list of friend names of the specified authorized user.
        /// </summary>
        /// <returns></returns>
        public async Task<List<string>> GetFriendsAsync()
        {
            var res = await GetAsync("http://codeforces.com/api/user.friends");
            return res.Result;
        }
    }
}
