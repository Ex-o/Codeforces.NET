using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace cfapi.Objects
{
    public class Problem : IApiObject
    {
        [JsonProperty("contestId")]
        public int ContestId { get; set; }

        [JsonProperty("problemsetName")]
        public string ProblemSetName { get; set; }

        [JsonProperty("index")]
        public string Index { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public ProblemType Type { get; set; }

        [JsonProperty("points")]
        public float Points { get; set; }

        [JsonProperty("rating")]
        public int Rating { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }
}
