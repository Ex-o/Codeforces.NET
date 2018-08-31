using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace cfapi.Objects
{
    public class Party : IApiObject
    {
        [JsonProperty("contestId")]
        public int ContestId { get; set; }

        [JsonProperty("members")]
        public List<Member> Members { get; set; }

        [JsonProperty("participantType")]
        public ParticipantType Type { get; set; }

        [JsonProperty("teamId")]
        public int TeamId { get; set; }

        [JsonProperty("teamName")]
        public string TeamName { get; set; }

        [JsonProperty("ghost")]
        public bool IsGhost { get; set; }

        [JsonProperty("room")]
        public int Room { get; set; }

        [JsonProperty("startTimeSeconds")]
        public int StartTime { get; set; }
    }
}
