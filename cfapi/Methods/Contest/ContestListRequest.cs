using System.Collections.Generic;
using System.Threading.Tasks;
using cfapi.Objects;

namespace cfapi.Methods
{
    public class ContestListRequest : RequestBase<Contest> 
    {
        /// <summary>
        /// Gets a list of Round/Gym Contests.
        /// </summary>
        /// <param name="includeGym"></param>
        /// <returns>A list of Contest objects</returns>
        public async Task<List<Contest>> GetContestListAsync(bool includeGym = false)
        {
           var ret = await GetAsync($"http://codeforces.com/api/contest.list?gym={includeGym.ToString()}");

           return ret.Result;
        }

        /// <summary>
        /// Gets a list of Round/Gym Contests.
        /// </summary>
        /// <param name="includeGym"></param>
        /// <returns>A list of Contest objects</returns>
        public List<Contest> GetContestList(bool includeGym = false)
        {
            return Get($"http://codeforces.com/api/contest.list?gym={includeGym.ToString()}").Result;
        }
    }
}