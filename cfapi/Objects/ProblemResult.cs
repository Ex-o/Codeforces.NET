using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace cfapi.Objects
{
    public class ProblemResult : IApiObject
    {
        [JsonProperty("points")]
        public float Points { get; set; }

        [JsonProperty("penalty")]
        public int Penalty { get; set; }

        [JsonProperty("rejectedAttemptCount")]
        public int RejectedAttemptsCount { get; set; }

        [JsonProperty("type")]
        public ProblemResultType Type { get; set; }

        [JsonProperty("bestSubmissionTimeSeconds")]
        public int BestSubmissionTime { get; set; }
    }
}
