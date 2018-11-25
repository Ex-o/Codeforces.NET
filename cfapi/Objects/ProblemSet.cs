using System.Collections.Generic;
using Newtonsoft.Json;

namespace cfapi.Objects
{
    public class ProblemSet : IApiObject
    {
        [JsonProperty("problems")]
        public List<Problem> Problems { get; set; }

        [JsonProperty("problemStatistics")]
        public List<ProblemStatistics> Statisics { get; set; }
    }
}