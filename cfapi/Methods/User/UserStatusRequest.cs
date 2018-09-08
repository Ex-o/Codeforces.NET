using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using cfapi.Objects;

namespace cfapi.Methods
{
    public class UserStatusRequest : RequestBase<Submission>
    {
        /// <summary>
        /// Requests a list of submissions of the specified user.
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="from"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<List<Submission>> GetUserSubmissionsAsync(string userHandle, int from = 1, int count = 1)
        {
            string req = $"http://codeforces.com/api/user.status?handle={userHandle}";

            if (count > 1)
                req += $"&count={count}";
            if (from > 1)
                req += $"&from{from}";

            var res = await base.GetAsync(req);
            return res.Result;
        }

        /// <summary>
        /// Requests a list of submissions of the specified user.
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="from"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<Submission> GetUserSubmissions(string userHandle, int from = 1, int count = 1)
        {
            string req = $"http://codeforces.com/api/user.status?handle={userHandle}";

            if (count > 1)
                req += $"&count={count}";
            if (from > 1)
                req += $"&from{from}";

            var res = Get(req);
            return res.Result;
        }
    }
}