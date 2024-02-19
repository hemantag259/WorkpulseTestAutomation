using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using RazorEngine.Compilation.ImpromptuInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkpulseTestAutomation.Common
{
    public class basetestpractice
    {

        public static ExtentTest extent;
        public static ExtentReports extentreport;
        public static ExtentV3HtmlReporter reporter;
       
        [OneTimeSetUp]
        public static void report()
        {
            var combinepath = Path.GetFullPath(Path.Combine(@"E:\Workpulse documents\Automation\WorkpulseTestAutomation\Reports")) + "ExtentReport" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html";
            extentreport = new ExtentReports();
            reporter = new ExtentV3HtmlReporter(combinepath);
            extentreport.AttachReporter(reporter);
        }

        [OneTimeTearDown]
        public void extentflush()
        {
            extentreport.Flush();
        }
    }
}
