using System.Collections.Generic;
using System.Threading.Tasks;
using cfapi.Objects;

namespace cfapi.Methods
{
    public class ContestStandingsRequest : RequestBase<Standing>
    {
        /// <summary>
        /// Requests standings of the specified contest.
        /// </summary>
        /// <param name="contestId"></param>
        /// <param name="from"></param>
        /// <param name="count"></param>
        /// <param name="handles"></param>
        /// <param name="room"></param>
        /// <param name="showUnofficial"></param>
        /// <returns></returns>
        public async Task<Standing> GetContestStandingsAsync(int contestId, int from = 1, int count = 0, List<string> handles = null, int room = 0, bool showUnofficial = false)
        {
            string req = $"http://codeforces.com/api/contest.standings?contestId={contestId}";

            if (count != 0) 
                req += $"&from={from}&count={count}";
            if (showUnofficial)
                req += "&from=true";

            var ret = await GetAsync(req);
            return ret.Result[0];
        }
    }
}