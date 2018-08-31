using System;
using System.Threading.Tasks;
using cfapi.Methods;
using cfapi.Methods.Request;

namespace cfapiClient
{

    internal class Program
    {
        public static async Task RunMyChild()
        {
            var request = new UserStatusRequest();
            var submissions = await request.GetUserSubmissionsAsync("Laggy", from: 1, count: 10);
            
            submissions.ForEach((sub) =>
            {
                sub.Problem.Tags.ForEach(Console.WriteLine);
            });
        }

        static void Main(string[] args)
        {
            RunMyChild();

            Console.Read();
        }
    }
}
