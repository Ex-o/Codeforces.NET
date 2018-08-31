using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cfapi.Methods.Request
{
    public class SecurityToken
    {
        /// <summary>
        /// Codeforces API Key.
        /// https://codeforces.com/settings/api
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Codeforces API Secret.
        /// https://codeforces.com/settings/api
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// Randomly assigned value.
        /// </summary>
        public string Random { get; set; }
    }
}
