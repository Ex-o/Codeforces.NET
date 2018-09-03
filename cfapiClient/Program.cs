using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cfapi.Methods;
using cfapi.Methods.Request;
using cfapi.Objects;

namespace cfapiClient
{
    internal class Program
    {
        public static async Task RunMyChild()
        {
            var request = new UserStatusRequest();
            var submissions = await request.GetUserSubmissionsAsync("Laggy", from: 1, count: 10);

            var anotherRequest = new UserInfoRequest();
            var user = anotherRequest.GetUserInfo("Laggy");
            var users = await anotherRequest.GetUsersInfoAsync(new [] {"Laggy", "majk", "tourist"});

            var yetAnotherRequest = new ContestRatingChangesRequest();
            var changes = await yetAnotherRequest.GetRatingChangesAsync(contestId: 1000);

            foreach (var change in changes)
            {
                Console.WriteLine($"{change.Handle} has got {change.NewRating - change.OldRating}");
            }
        }

        public static async Task BruteforceProblems()
        {
            var contestReq = new ContestListRequest();

            var contests = await contestReq.GetContestListAsync(includeGym: false);
            foreach (var contest in contests.Where(i => i.Phase == ContestPhase.FINISHED))
            {
                var req = new ContestStandingsRequest();
                var contestDetails = await req.GetContestStandingsAsync(contestId: contest.Id, from: 1, count: 1);
                var contestProblems = contestDetails?.Problems;
                Console.WriteLine(contest.Id);
                if(contestProblems == null) continue;
                
                foreach (var problem in contestProblems)
                {
                    if(problem.Index == "C" && problem.Tags.Contains("fft"))
                    {
                        Console.WriteLine($"Found at ContestId: {problem.ContestId}");
                    }
                }
            }
            Console.WriteLine("Done!");
        }

        static void Main(string[] args)
        {
            BruteforceProblems();

            Console.Read();
        }
    }
}
