using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace cfapi.Objects
{
    public class ProblemStatistics : IApiObject
    {
        [JsonProperty("contestId")]
        public int ContestId { get; set; }

        [JsonProperty("index")]
        public string Index { get; set; }

        [JsonProperty("solvedCount")]
        public int SolvedCount { get; set; }
    }
}
