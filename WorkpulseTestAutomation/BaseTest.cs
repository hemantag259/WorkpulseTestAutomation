using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
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
            
           //var path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory) + @"\Reports") + "..\\..\\..\\"  + "ExtentReport" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + " .html";
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            var combinepath = path + @"\Reports";
            // extent = new ExtentReports(path,false);
            // extent = new ExtentReports(@"E:\Workpulse documents\Automation\Workpulse Project\Workpulse Project\Reports" + "ExtentReport.html" ;
            extent = new ExtentReports();
            HtmlReporter = new ExtentV3HtmlReporter(combinepath);
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
