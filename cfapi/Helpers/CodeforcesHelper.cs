using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using cfapi.Methods.Request;

namespace cfapi.Helpers
{
    public static class CodeforcesHelper
    {
        /// <summary>
        /// Gets time in Unix format.
        /// </summary>
        /// <returns></returns>
        public static int GetCodeforcesTime()
        {
            return (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }
        /// <summary>
        /// Generates authorized signature for requests requiring authorization.
        /// </summary>
        /// <param name="args"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static string GenerateSignature(string args, SecurityToken token)
        {
            if (string.IsNullOrEmpty(token?.Key) ||
                string.IsNullOrEmpty(token.Secret) ||
                string.IsNullOrEmpty(token.Random))
            {
                return "";
            }

            var flag = args.Contains("?") ? "&" : "?";

            var signature =
                $"{flag}apiKey={token.Key}&time={CodeforcesHelper.GetCodeforcesTime()}";

            var hash = $"{token.Random}/{args}{signature}#{token.Secret}";
            Console.WriteLine("To be hashed:\n" + hash);
            var bytes = Encoding.UTF8.GetBytes(hash);
            using (var alg = SHA512.Create())
            {
                alg.ComputeHash(bytes);
                signature += $"&apiSig={token.Random}" + BitConverter.ToString(alg.Hash).Replace("-", "").ToLower();
            }

            return signature;
        }
        public static double GetWinProbablility(double ra, double rb)
        {
            return 1.0 / (1.0 + Math.Pow(10.0, (rb - ra) / 400.0));
        }
        public static double AggregateRatings(List<double> teamRatings)
        {
            double left = 1;
            double right = 1E4;

            for (int tt = 0; tt < 100; tt++)
            {
                double r = (left + right) / 2.0;

                double rWinsProbability = 1.0;
                foreach(var rate in teamRatings)
                    rWinsProbability *= GetWinProbablility(r, rate);

                double rating = Math.Log10(1 / (rWinsProbability) - 1) * 400 + r;

                if (rating > r)
                    left = r;
                else
                    right = r;
            }

            return (left + right) / 2.0;
        }
    }
}
