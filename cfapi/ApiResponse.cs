using System;
using System.Collections.Generic;
using cfapi.Objects;
using Newtonsoft.Json;
using cfapi;

namespace cfapi
{
    
    public class ApiResponse<T> 
    {
        /// <summary>
        /// Request status.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Request comment.
        /// </summary>
        [JsonProperty("comment")]
        public string Comment { get; set; }

        /// <summary>
        /// Request object(s) result always in a list!
        /// </summary>
        [JsonProperty("result")]
        public List<T> Result { get; set; }

    }
}
