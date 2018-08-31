using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace cfapi.Objects
{
    public class Hack : IApiObject
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("creationTimeSeconds")]
        public int CreationTime { get; set; }

        [JsonProperty("hacker")]
        public Party Hacker { get; set; }


        [JsonProperty("defender")]
        public Party Defender { get; set; }

        [JsonProperty("verdict")]
        public HackVerdict Verdict { get; set; }

        [JsonProperty("problem")]
        public Problem Problem { get; set; }

        [JsonProperty("test")]
        public string Test { get; set; }

        [JsonProperty("judgeProtocol")]
        public JudgeProtocol JudgeProtocol { get; set; }
    }
}
