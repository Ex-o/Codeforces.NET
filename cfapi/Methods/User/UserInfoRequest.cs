
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cfapi.Objects;

namespace cfapi.Methods
{
    public class UserInfoRequest : RequestBase<User>
    {
        /// <summary>
        /// Requests user info of the specified user.
        /// </summary>
        /// <param name="userHandle"></param>
        /// <returns></returns>
        public async Task<User> GetUserInfoAsync(string userHandle)
        {
            var res = await GetAsync($"http://codeforces.com/api/user.info?handles={userHandle}");
            return res?.Result[0];
        }

        public async Task<List<User>> GetUsersInfoAsync(string[] userHandles)
        {
            var userList = new List<User>();
            foreach (var handle in userHandles.ToList())
            {
                var user = await GetUserInfoAsync(handle);
                if(user != null)
                    userList.Add(user);
            }

            return userList;
        }
    }
}