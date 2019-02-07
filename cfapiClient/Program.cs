using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using cfapi.HTTP;
using cfapi.Methods;
using cfapi.Methods.Request;
using cfapi.Objects;

namespace cfapiClient
{
    public class ICPCTeam
    {
        public string Country { get; set; }

        public string University { get; set; }

        public string Member1 { get; set; }

        public string Member2 { get; set; }

        public string Member3 { get; set; }

        public double TeamRating { get; set; }

    }
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

        public static async Task BuildGym()
        {
            var req = new ContestListRequest();
            var gymList = await req.GetContestListAsync(true);

            Dictionary<int, List<Problem>> dic = new Dictionary<int, List<Problem>>();
            foreach (var contest in gymList)
            {
                var req2 = new ContestStandingsRequest();
                var standings = await req2.GetContestStandingsAsync(contest.Id, 1, 1);

                dic.Add(contest.Id, new List<Problem>());
                foreach (var problem in standings.Problems)
                {
                    dic[contest.Id].Add(problem);
                }
            }

            Console.WriteLine("Done");
            var properDic = dic.ToDictionary(k => k.Key.ToString(), v => v.Value);
            var serializer = new JavaScriptSerializer().Serialize(properDic);
            File.WriteAllText("contests.json", serializer);
        }

        public static async void GetSet()
        {
            var req = new ProblemsRequest();
            var res = await req.GetProblemSetAsync();

            foreach (var problem in res.Problems)
            {
                Console.WriteLine(problem.Name);
            }
        }

        public static Dictionary<string, int> count = new Dictionary<string, int>();
        public static async void GetLegends()
        {
            var req = new ContestListRequest();
            var contests = await req.GetContestListAsync();
            contests = contests.Where(i => i.Phase == ContestPhase.FINISHED).ToList();

            foreach(var contest in contests)
            {
                try
                {
                    var req2 = new ContestStandingsRequest();
                    var standings = await req2.GetContestStandingsAsync(contest.Id, 1, 1, null, 0, false);

                    var users = standings.Rows.FindAll(i => i.Rank == 1);
                    foreach (var user in users)
                    {
                        
                        if (count.ContainsKey(user.Party.Members[0].Handle))
                            count[user.Party.Members[0].Handle]++;
                        else
                            count.Add(user.Party.Members[0].Handle, 1);
                    }
                    await Task.Delay(205);
                }
                catch { }
            }
            count = count.OrderByDescending(i => i.Value).ToDictionary(x => x.Key, x => x.Value);

            int ok = 0;
            foreach(var x in count)
            {
                Console.WriteLine($"{ok + 1}) {x.Key} has {x.Value} wins.");
                ok++;
                if (ok == 25) break;
            }
        }
        static void Main(string[] args)
        {
            List<ICPCTeam> icpcTeams = new List<ICPCTeam>();
            using (SqlConnection con = new SqlConnection("Data Source = 192.168.134.133, 1433; Network Library=DBMSSOCN; Initial Catalog = SRO_CERTIFICATION; User ID = sa; Password = Khaled1337"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM _ICPCEntries", con);
                var reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    icpcTeams.Add(new ICPCTeam()
                    {
                        Country = reader["Country"] as string,
                        University = reader["University"] as string,
                        Member1 = reader["Member1"] as string,
                        Member2 = reader["Member2"] as string,
                        Member3 = reader["Member3"] as string,
                        TeamRating = 0
                    });
                }
            }
            foreach(var team in icpcTeams)
            {
                List<string> members = new List<string>();
                if (!string.IsNullOrEmpty(team.Member1)) members.Add(team.Member1);
                if (!string.IsNullOrEmpty(team.Member2)) members.Add(team.Member2);
                if (!string.IsNullOrEmpty(team.Member3)) members.Add(team.Member3);

                List<double> ratings = new List<double>();
                foreach(var member in members)
                {
                    var req = new UserInfoRequest();
                    var user = req.GetUserInfo(member);
                    ratings.Add(user.Rating);

                    Thread.Sleep(150);
                }

                var teamRating = cfapi.Helpers.CodeforcesHelper.AggregateRatings(ratings);
                team.TeamRating = teamRating;
            }

            icpcTeams = icpcTeams.OrderByDescending(i => i.TeamRating).ToList();
            int rank = 1;
            Console.WriteLine("<table><thead><tr><th>Rank</th> <th>Country</th> <th>University</th> <th>Member1</th> <th>Member2</th> <th>Member3</th> <th>Team Rating</th></tr> </thead>");
            foreach(var team in icpcTeams)
            {
                if(team.TeamRating == 1.0)
                    Console.WriteLine($"<tr> <td>{rank++}</td> <td>{team.Country}</td> <td>{team.University}</td> <td>{team.Member1}</td> <td>{team.Member2}</td> <td>{team.Member3}</td> <td>{team.TeamRating}</td> </tr>");
                else
                    Console.WriteLine($"<tr> <td>{rank++}</td> <td>{team.Country}</td> <td>{team.University}</td> <td>[user:{team.Member1}]</td> <td>[user:{team.Member2}]</td> <td>[user:{team.Member3}]</td> <td>{team.TeamRating.ToString("0.###")}</td> </tr>");
            }
            Console.WriteLine("</table>");
            Console.Read();
        }
    }
}
