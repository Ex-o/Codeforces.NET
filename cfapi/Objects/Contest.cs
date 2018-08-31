using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cfapi.Methods;
using Newtonsoft.Json;

namespace cfapi.Objects
{
    public class Contest : IApiObject
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public ContestType Type { get; set; }

        [JsonProperty("phase")]
        public ContestPhase Phase { get; set; }

        [JsonProperty("frozen")]
        public bool IsFrozen { get; set; }

        [JsonProperty("durationSeconds")]
        public int Duration { get; set; }

        [JsonProperty("startTimeSeconds")]
        public int StartTime { get; set; }

        [JsonProperty("relativeTimeSeconds")]
        public int RelativeTime { get; set; }

        [JsonProperty("preparedBy")]
        public string Author { get; set; }

        [JsonProperty("websiteUrl")]
        public string WebsiteUrl { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("difficulty")]
        public int Difficulty { get; set; }

        [JsonProperty("kind")]
        public string ContestKind { get; set; }

        [JsonProperty("icpcRegion")]
        public string IcpcRegion { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("season")]
        public string Season { get; set; }

        public Standing Standings { get; private set; }

        /// <summary>
        /// Sets standings of the current contest.
        /// </summary>
        /// <returns></returns>
        public async Task LoadStandingsAsync()
        {
            if (this.Id == 0)
            {
                throw new NotImplementedException();
            }

            Standings = await (new ContestStandingsRequest()).GetContestStandingsAsync(this.Id);
        }
    }
}
