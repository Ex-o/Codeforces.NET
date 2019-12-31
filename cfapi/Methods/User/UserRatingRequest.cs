using cfapi.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cfapi.Methods
{
    public class UserRatingRequest : RequestBase<RatingChange>
    {
        public List<RatingChange> GetRatingChanges(string userHandle)
        {
            string request = $"http://codeforces.com/api/user.rating?handle={userHandle}";
            var res = Get(request);

            return res.Result;
        }
    }
}
