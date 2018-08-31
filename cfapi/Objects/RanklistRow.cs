using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace cfapi.Objects
{
    public class RanklistRow : IApiObject
    {
        [JsonProperty("party")]
        public Party Party { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("points")]
        public float Points { get; set; }

        [JsonProperty("penalty")]
        public int Penalty { get; set; }

        [JsonProperty("successfulHackCount")]
        public int SucessfulHackCount { get; set; }

        [JsonProperty("unsuccessfulHackCount")]
        public int UnSucessfulHackCount { get; set; }

        [JsonProperty("lastSubmissionTimeSeconds")]
        public int LastSubmissionTime { get; set; }
    }
}
