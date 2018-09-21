using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public static async Task Test()
        {
            var request = new UserStatusRequest();
            var submissions = await request.GetUserSubmissionsAsync("handle");
            var acceptedSubmissions = submissions.Where(i => i.Verdict == SubmissionVerdict.OK);
        }

        public static async Task GetTopHacks()
        {
            var req = new ContestStandingsRequest();
            var standings = await req.GetContestStandingsAsync(contestId: 1051, from: 1, count: 100000, showUnofficial: true);

            standings.Rows = standings.Rows.OrderByDescending(i => i.SucessfulHackCount)
                .ThenByDescending(i => -i.UnSucessfulHackCount).ToList();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{standings.Rows[i].Party.Members[0].Handle} has +{standings.Rows[i].SucessfulHackCount} | -{standings.Rows[i].UnSucessfulHackCount}");
            }
        }
        static void Main(string[] args)
        {
            GetTopHacks();

            Console.Read();
        }
    }
}
