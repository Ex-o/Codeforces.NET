using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace cfapi.HTTP
{
    public class Session
    {
        public string CsrfToken { get; set; }
        public string Ftaa { get; set; }
        public string Bfaa { get; set; }

        public bool IsLoggedIn { get; set; }

        public async Task LogIn(string userName, string password)
        {
            if (IsLoggedIn)
                LogOut();

            HttpWebRequest request = null;
            request = HttpWebRequest.Create("http://codeforces.com/enter") as HttpWebRequest;
            HttpWebResponse TheRespone = (HttpWebResponse)request.GetResponse();
            String setCookieHeader = TheRespone.Headers[HttpResponseHeader.SetCookie];


        }

        private void LogOut()
        {
            throw new NotImplementedException();
        }
    }
}

