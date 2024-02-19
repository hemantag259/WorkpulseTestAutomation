using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkpulseTestAutomation.Common;

namespace WorkpulseTestAutomation.Web_Tests
{
    public class practice : basetestpractice
    {
        [Test]
        public static void test()
        {
            String path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            //IWebDriver driver = new ChromeDriver(@"E:\Workpulse documents\Automation\WorkpulseTestAutomation\WorkpulseTestAutomation\drivers");
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://opssite.workpulse.com/");
            driver.FindElement(By.Id("username"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.Id("password"));
            extent = null;
            string methodname = TestContext.CurrentContext.Test.MethodName.ToString();

            extent = extentreport.CreateTest(methodname);
            extent.Log(Status.Info, "Login");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementExists(By.Id("username")));
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(20);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(250);
            IWebElement element = fluentwait.Until(dom => dom.FindElement(By.Id("username")));
            string connectionstring = null;
            SqlConnection sql = new SqlConnection(connectionstring);
            sql.Open();
            string query = null;
            var cmd = new SqlCommand(query, sql);
            var testdata = new DataTable();
            using (var da = new SqlDataAdapter(cmd))
            {
                da.Fill(testdata);
            }
            var resultrows = testdata.Select();
            var usernamedata = resultrows[0]["Username"].ToString();

        }

        
    }
}
