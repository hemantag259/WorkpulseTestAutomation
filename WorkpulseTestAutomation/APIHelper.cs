using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workpulse_Project
{
    public class APIHelper
    {
        public static Dictionary<string, string> GetHeaderInfo(string BearerToken)
        {
            return new Dictionary<string, string>
            {
                {"Authorization", BearerToken},
                {"Accept-Encoding", "gzip, deflate, br" },
                {"Accept", "application/json, text/plain, */*" }
            };
        }
    }
}
