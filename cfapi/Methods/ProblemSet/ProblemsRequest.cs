using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cfapi.Methods.Request;
using cfapi.Objects;

namespace cfapi.Methods
{
    public class ProblemsRequest : RequestBase<ProblemSet>
    {
        public async Task<ProblemSet> GetProblemSetAsync(string[] tags = null, string problemsetName = null)
        {
            string req = "http://codeforces.com/api/problemset.problems";
           
            if (tags != null && tags.Length > 0)
            {
                req += "?tags=";

                for (int i = 0; i < tags.Length; i++)
                {
                    req += tags[i];

                    if (i > 0 && i < tags.Length - 1)
                    {
                        req += ";";
                    }
                }

                req += "&";
            }

            var ret = await base.GetAsync(req);

            return ret?.Result[0];
        }
    }
}