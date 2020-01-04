using cfapi.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cfapi.Helpers
{
    public static class Filter
    {
        public static List<Submission> Unique(this List<Submission> list)
        {
          return list.Where(x => x.Verdict == SubmissionVerdict.OK).GroupBy(x => x.Problem.Name).Select(y => y.First()).ToList();          
        }
        public static List<Submission> FilterSubmissions(this List<Submission> list, List<string> tags, bool inclusive = false)
        {
            if (tags.Count == 1 && tags.First() == "") return list;

            if(inclusive)
            {
                return list.Where(x => tags.All(y => x.Problem.Tags.Contains(y))).ToList();
            }
            return list.Where(x => x.Problem.Tags.Intersect(tags).Any()).ToList();
        }
    }
}
