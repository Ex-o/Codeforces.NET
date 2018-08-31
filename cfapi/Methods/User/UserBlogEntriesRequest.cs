using cfapi.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cfapi.Methods
{
    public class UserBlogEntriesRequest : RequestBase<BlogEntry>
    {
        /// <summary>
        /// Requests all blog entries of the specified user.
        /// </summary>
        /// <param name="userHandle"></param>
        /// <returns></returns>
        public async Task<List<BlogEntry>> GetBlogEntriesAsync(string userHandle)
        {
            var res = await GetAsync($"http://codeforces.com/api/user.blogEntries?handle={userHandle}");

            return res.Result;
        }

        /// <summary>
        /// Requests all blog entries of the specified user.
        /// </summary>
        /// <param name="userHandle"></param>
        /// <returns></returns>
        public List<BlogEntry> GetBlogEntries(string userHandle)
        {
            var res = Get($"http://codeforces.com/api/user.blogEntries?handle={userHandle}");

            return res.Result;
        }
    }
}
