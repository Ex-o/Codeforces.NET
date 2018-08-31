using Newtonsoft.Json;

namespace cfapi.Objects
{
    public class JudgeProtocol : IApiObject
    {
        [JsonProperty("manual")]
        public bool IsManual { get; set; }

        [JsonProperty("protocol")]
        public string Protocol { get; set; }

        [JsonProperty("verdict")]
        public string Verdict { get; set; }
    }
}