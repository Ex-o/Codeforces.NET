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
        /// <summary>
        /// Comment Id.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Creation time in Unix format.
        /// </summary>
        [JsonProperty("creationTimeSeconds")]
        public int CreationTime { get; set; }

        /// <summary>
        /// Comment creator handle.
        /// </summary>
        [JsonProperty("commentatorHandle")]
        public string CommentatorHandle { get; set; }

        /// <summary>
        /// Comment HTML content.
        /// </summary>
        [JsonProperty("text")]
        public string Content { get; set; }

        /// <summary>
        /// Comment Parent Id.
        /// </summary>
        [JsonProperty("parentCommentId")]
        public int ParentCommentId { get; set; }

        /// <summary>
        /// Rating (up/down) votes.
        /// </summary>
        [JsonProperty("rating")]
        public int Rating { get; set; }
    }
}
