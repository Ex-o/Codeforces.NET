using System.Collections.Generic;
using System.Threading.Tasks;
using cfapi.Objects;

namespace cfapi.Methods
{
    public class ContestRatingChangesRequest : RequestBase<RatingChange>
    {
        /// <summary>
        /// Gets all rating changes of the contest specified.
        /// </summary>
        /// <param name="contestId"></param>
        /// <returns></returns>
        public async Task<List<RatingChange>> GetRatingChangesAsync(int contestId)
        {
            var ret = await GetAsync($"http://codeforces.com/api/contest.ratingChanges?contestId={contestId}");
            return ret.Result;
        }

        /// <summary>
        /// Gets all rating changes of the contest specified.
        /// </summary>
        /// <param name="contestId"></param>
        /// <returns></returns>
        public List<RatingChange> GetRatingChanges(int contestId)
        {
            return Get($"http://codeforces.com/api/contest.ratingChanges?contestId={contestId}").Result;
        }
    }
}