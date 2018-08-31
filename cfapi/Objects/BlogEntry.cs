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
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("originalLocale")]
        public string OriginalLocale { get; set; }

        [JsonProperty("creationTimeSeconds")]
        public int CreationTime { get; set; }

        [JsonProperty("authorHandle")]
        public string AuthorHandle { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("modificationTimeSeconds")]
        public string ModificationTime { get; set; }

        [JsonProperty("allowViewHistory")]
        public bool ViewHistory { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("rating")]
        public int Rating { get; set; }

        public List<BlogComment> Comments { get; private set; }
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
