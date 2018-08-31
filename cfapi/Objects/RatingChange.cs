using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace cfapi.Objects
{
    public class RatingChange : IApiObject
    {
        [JsonProperty("contestId")]
        public int ContestId { get; set; }

        [JsonProperty("contestName")]
        public string ContestName { get; set; }

        [JsonProperty("handle")]
        public string Handle { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("ratingUpdateTimeSeconds")]
        public int RatingUpdateTime { get; set; }

        [JsonProperty("oldRating")]
        public int OldRating { get; set; }

        [JsonProperty("newRating")]
        public int NewRating { get; set; }
    }
}
