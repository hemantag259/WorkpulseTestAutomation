using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workpulse_Project
{
    public class BaseTest
    {
        public static ExtentTest test;
        public static ExtentReports extent;
        public static ExtentV3HtmlReporter HtmlReporter;
        
        
        [OneTimeSetUp]
        public void ExtentStart()
        {
            
           var path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory)) + "..\\..\\..\\" +"ExtentReport" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + " .html";

           // extent = new ExtentReports(path,false);
           // extent = new ExtentReports(@"E:\Workpulse documents\Automation\Workpulse Project\Workpulse Project\Reports" + "ExtentReport.html" ;
            extent = new ExtentReports();
            HtmlReporter = new ExtentV3HtmlReporter(path);
            extent.AttachReporter(HtmlReporter);

            HtmlReporter.Config.DocumentTitle = "Automation Report";
            HtmlReporter.Config.ReportName = "Test Report";
            HtmlReporter.Config.Theme= Theme.Dark;




        }
        

        [OneTimeTearDown]

        public void ExtentClose()
        {
            extent.Flush();
        }
    }

}
