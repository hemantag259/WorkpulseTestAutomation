using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Workpulse_Project
{
    public class TestHelper
    {
     
            public static string AssemblyDirectory
            {
                get
                {
                    var codeBase = Assembly.GetExecutingAssembly().CodeBase;
                    var uri = new UriBuilder(codeBase);
                    var path = Uri.UnescapeDataString(uri.Path);
                    return Path.GetDirectoryName(path);
                }
            }
        }
}
