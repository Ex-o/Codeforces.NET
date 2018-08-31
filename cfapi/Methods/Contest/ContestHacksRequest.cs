using System.Collections.Generic;
using System.Threading.Tasks;
using cfapi.Methods.Request;
using cfapi.Objects;

namespace cfapi.Methods
{
    public class ContestHacksRequest : AuthorizedRequestBase<Hack>
    {
        public ContestHacksRequest(SecurityToken token) 
            : base(token) { }

        /// <summary>
        /// Requests a list of hacks of specified contest.
        /// </summary>
        /// <param name="contestId">The Id of the Contest (can be found in the url)</param>
        /// <returns>A List of Hack objects.</returns>
        public async Task<List<Hack>> GetHacksAsync(int contestId)
        {
            var ret = await GetAsync($"http://codeforces.com/api/contest.hacks?contestId={contestId}");
            return ret.Result;
        }

        /// <summary>
        /// Requests a list of hacks of specified contest.
        /// </summary>
        /// <param name="contestId">The Id of the Contest (can be found in the url)</param>
        /// <returns>A List of Hack objects.</returns>
        public List<Hack> GetHacks(int contestId)
        {
            return Get($"http://codeforces.com/api/contest.hacks?contestId={contestId}").Result;
        }
    }
}