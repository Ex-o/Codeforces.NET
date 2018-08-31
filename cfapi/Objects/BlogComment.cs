using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace cfapi.Objects
{
    public class BlogComment : IApiObject
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("creationTimeSeconds")]
        public int CreationTime { get; set; }

        [JsonProperty("commentatorHandle")]
        public string CommentatorHandle { get; set; }

        [JsonProperty("text")]
        public string Content { get; set; }

        [JsonProperty("parentCommentId")]
        public int ParentCommentId { get; set; }

        [JsonProperty("rating")]
        public int Rating { get; set; }
    }
}
