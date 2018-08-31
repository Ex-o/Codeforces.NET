using cfapi.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cfapi.Methods
{
    public class ContestStatusRequest : RequestBase<Submission>
    {
        /// <summary>
        /// Requests a list of contest submissions async.
        /// </summary>
        /// <param name="contestId"></param>
        /// <param name="handle"></param>
        /// <param name="from"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<List<Submission>> GetContestSubmissionsAsync(int contestId, string handle = null, int from = 1, int count = 1)
        {
            string request = $"http://codeforces.com/api/contest.status?contestId={contestId}";
            if (handle != null)
                request += $"&handles={handle}";
            if (from != 1)
                request += $"&from={from}";
            if (count != 1)
                request += $"&from={from}";

            var res = await GetAsync(request);
            return res.Result;
        }

        /// <summary>
        /// Requests a list of contest submissions.
        /// </summary>
        /// <param name="contestId"></param>
        /// <param name="handle"></param>
        /// <param name="from"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<Submission> GetContestSubmissions(int contestId, string handle = null, int from = 1, int count = 1)
        {
            string request = $"http://codeforces.com/api/contest.status?contestId={contestId}";
            if (handle != null)
                request += $"&handles={handle}";
            if (from != 1)
                request += $"&from={from}";
            if (count != 1)
                request += $"&from={from}";

            var res = Get(request);
            return res.Result;
        }
    }
}
