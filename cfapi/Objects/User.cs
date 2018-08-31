using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cfapi.Methods;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace cfapi.Objects
{
    public class User : IApiObject
    {
        #region Fields
        [JsonProperty("handle")]
        public string Handle { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("vkId")]
        public string VkId { get; set; }

        [JsonProperty("openId")]
        public string OpenId { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("organization")]
        public string Organization { get; set; }

        [JsonProperty("contribution")]
        public int Contribution { get; set; }

        [JsonProperty("rank")]
        public string Rank { get; set; }

        [JsonProperty("rating")]
        public int Rating { get; set; }

        [JsonProperty("maxRating")]
        public int MaxRating { get; set; }

        [JsonProperty("lastOnlineTimeSeconds")]
        public  int LastOnlineTimeSeconds { get; set; }

        [JsonProperty("registrationTimeSeconds")]
        public int RegistrationTimeSeconds { get; set; }

        [JsonProperty("friendOfCount")]
        public int FriendOfCount { get; set; }

        [JsonProperty("avatar")]
        public string AvatarUrl { get; set; }

        [JsonProperty("titlePhoto")]
        public string TitlePhotoUrl { get; set; }

        public List<BlogEntry> Blogs { get; private set; }

        public List<Submission> Submissions { get; private set; }

        #endregion

        /// <summary>
        /// Sets Blogs of the current user.
        /// </summary>
        /// <returns></returns>
        public async Task LoadBlogsAsync()
        {
            if (this.Handle == null)
            {
                throw new Exception("User information not request!");
            }

            Blogs = await (new BlogEntryRequest()).GetBlogsAsync(this.Handle);
        }

        /// <summary>
        /// Sets submissions of the current user.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task LoadSubmissionsAsync(int from = 0, int count = 0)
        {
            if (this.Handle == null)
            {
                throw new Exception("User information not request");
            }

            Submissions = await (new UserStatusRequest()).GetUserSubmissionsAsync(this.Handle);
        }
    }
         
}
