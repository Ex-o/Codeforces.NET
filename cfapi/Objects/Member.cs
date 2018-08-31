using Newtonsoft.Json;

namespace cfapi.Objects
{
    public class Member : IApiObject
    {
        [JsonProperty("handle")]
        public string Handle { get; set; }
    }
}