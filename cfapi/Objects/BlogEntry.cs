using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cfapi.Methods;
using Newtonsoft.Json;

namespace cfapi.Objects
{
    public class BlogEntry : IApiObject
    {
        /// <summary>
        /// Blog entry Id.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Original Locale of blog (EU/RU).
        /// </summary>
        [JsonProperty("originalLocale")]
        public string OriginalLocale { get; set; }

        /// <summary>
        /// Creation time of the blog in Unix format.
        /// </summary>
        [JsonProperty("creationTimeSeconds")]
        public int CreationTime { get; set; }

        /// <summary>
        /// Handle of the blog creator.
        /// </summary>
        [JsonProperty("authorHandle")]
        public string AuthorHandle { get; set; }

        /// <summary>
        /// Title of the blog.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Content of the blog in HTML.
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }

        /// <summary>
        /// Locale of the blog (RU/EN).
        /// </summary>
        [JsonProperty("locale")]
        public string Locale { get; set; }

        /// <summary>
        /// Last edit time in Unix format.
        /// </summary>
        [JsonProperty("modificationTimeSeconds")]
        public string ModificationTime { get; set; }

        /// <summary>
        /// View History Allow Flag
        /// </summary>
        [JsonProperty("allowViewHistory")]
        public bool ViewHistory { get; set; }

        /// <summary>
        /// List of tags of the blog.
        /// </summary>
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        /// <summary>
        /// Rating (up/down) votes.
        /// </summary>
        [JsonProperty("rating")]
        public int Rating { get; set; }

        /// <summary>
        /// Comments on the blog (must be loaded by calling LoadComments() first.
        /// </summary>
        public List<BlogComment> Comments { get; private set; }

        /// <summary>
        /// Loads comments of the blog object.
        /// </summary>
        /// <returns></returns>
        public async Task LoadComments()
        {
            if (this.Id == 0)
            {
                throw new Exception("Blog information not request!");
            }

            this.Comments = await (new BlogCommentsRequest()).GetBlogCommentsByIdAsync(this.Id);
        }
    }
}
