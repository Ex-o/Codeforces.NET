using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cfapi.Objects;

namespace cfapi.Methods
{
    public class BlogCommentsRequest : RequestBase<BlogComment>
    {
        /// <summary>
        /// Requests the comments of the specified blog.
        /// </summary>
        /// <param name="blogEntryId"></param>
        /// <returns></returns>
        public async Task<List<BlogComment>> GetBlogCommentsByIdAsync(int blogEntryId)
        {
            var res = await GetAsync($"http://codeforces.com/api/blogEntry.comments?blogEntryId={blogEntryId}");
            return res.Result;
        }
    }
}
