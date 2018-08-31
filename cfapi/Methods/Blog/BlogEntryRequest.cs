using System.Collections.Generic;
using System.Threading.Tasks;
using cfapi.Objects;

namespace cfapi.Methods
{
    public class BlogEntryRequest : RequestBase<BlogEntry>
    {
        /// <summary>
        /// Requests blogs of the specified user.
        /// </summary>
        /// <param name="userHandle"></param>
        /// <returns></returns>
        public async Task<List<BlogEntry>> GetBlogsAsync(string userHandle)
        {
            var res = await GetAsync($"http://codeforces.com/api/user.blogEntries?handle={userHandle}");
            return res.Result;
        }

        /// <summary>
        /// Requests the blog with the specified id.
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        public async Task<List<BlogEntry>> GetBlogByIdAsync(int blogId)
        {
            var res = await GetAsync($" http://codeforces.com/api/blogEntry.view?blogEntryId={blogId}");
            return res.Result;
        }

        /// <summary>
        /// Requests blogs of the specified user.
        /// </summary>
        /// <param name="userHandle"></param>
        /// <returns></returns>
        public List<BlogEntry> GetBlogs(string userHandle)
        {
            var res = Get($"http://codeforces.com/api/user.blogEntries?handle={userHandle}");
            return res.Result;
        }

        /// <summary>
        /// Requests the blog with the specified id.
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        public List<BlogEntry> GetBlogById(int blogId)
        {
            var res = Get($" http://codeforces.com/api/blogEntry.view?blogEntryId={blogId}");
            return res.Result;
        }
    }
}