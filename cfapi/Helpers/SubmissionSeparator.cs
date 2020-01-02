using cfapi.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cfapi.Helpers
{
    public class SubmissionSeparator
    {
        public List<Submission> CompleteList { get; set; }
        public List<Submission> ContestSubmissions { get; set; }
        public List<Submission> VirtualSubmissions { get; set; }
        public List<Submission> PracticeSubmissions { get; set;}
        public List<Submission> UnofficialSubmissions { get; set; }

        public void Separate(bool accepted)
        {
            foreach (var sub in CompleteList)
            {
                if (sub.Problem.Rating == 0) continue;
                bool flag = (sub.Verdict == SubmissionVerdict.OK && accepted) || (!accepted);
                if (flag)
                {
                    switch (sub.Author.Type)
                    {
                        case ParticipantType.PRACTICE:
                            PracticeSubmissions.Add(sub);
                            break;
                        case ParticipantType.VIRTUAL:
                            VirtualSubmissions.Add(sub);
                            break;
                        case ParticipantType.CONTESTANT:
                            ContestSubmissions.Add(sub);
                            break;
                        case ParticipantType.OUT_OF_COMPETITION:
                            UnofficialSubmissions.Add(sub);
                            break;
                    }
                }
            }
        }
        public SubmissionSeparator(List<Submission> list)
        {
            PracticeSubmissions = new List<Submission>();
            ContestSubmissions = new List<Submission>();
            VirtualSubmissions = new List<Submission>();
            UnofficialSubmissions = new List<Submission>();
            CompleteList = list;
        }
    }
}
