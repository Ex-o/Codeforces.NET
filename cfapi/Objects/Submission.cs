using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace cfapi.Objects
{
    public class Submission : IApiObject
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("contestId")]
        public int ContestId { get; set; }

        [JsonProperty("creationTimeSeconds")]
        public int CreationTime { get; set; }

        [JsonProperty("relativeTimeSeconds")]
        public int RelativeTime { get; set; }

        [JsonProperty("problem")]
        public Problem Problem { get; set; }

        [JsonProperty("author")]
        public Party Author { get; set; }

        [JsonProperty("programmingLanguage")]
        public string ProgrammingLanguage { get; set; }

        [JsonProperty("verdict")]
        public SubmissionVerdict Verdict { get; set; }

        [JsonProperty("testset")]
        public TestSet TestSet { get; set; }

        [JsonProperty("passedTestCount")]
        public int PassedTestsCount { get; set; }

        [JsonProperty("timeConsumedMillis")]
        public int TimeConsumed { get; set; }

        [JsonProperty("memoryConsumedBytes")]
        public int MemoryConsumed { get; set; }

    }
}
