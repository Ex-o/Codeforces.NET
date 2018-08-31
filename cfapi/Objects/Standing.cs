using System.Collections.Generic;
using Newtonsoft.Json;

namespace cfapi.Objects
{
    public class Standing : IApiObject
    {
        [JsonProperty("contest")]
        public Contest Contest { get; set; }

        [JsonProperty("problems")]
        public List<Problem> Problems { get; set; }

        [JsonProperty("rows")]
        public List<RanklistRow> Rows { get; set; }
    }
}