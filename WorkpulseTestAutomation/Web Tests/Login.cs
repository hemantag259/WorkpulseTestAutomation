using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkpulseTestAutomation.Common;

namespace WorkpulseTestAutomation
{

    public class Login : BaseTest
    {

        public static IWebDriver LoginWorkpulse()
        {

            IWebDriver driver;
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            driver = new ChromeDriver(path + @"\drivers\");
            test = null;
            String methodname = TestContext.CurrentContext.Test.MethodName.ToString();
            test = extent.CreateTest(methodname).Info("Automation Test for creation of the Book Task");

            driver.Navigate().GoToUrl("https://opssite.workpulse.com/");
            test.Log(Status.Info, "Navigate to OPS URL");

            driver.Manage().Window.Maximize();
            Thread.Sleep(5000);
            IWebElement username = driver.FindElement(By.Id("username"));
            IWebElement password = driver.FindElement(By.Id("password"));
            IWebElement accessid = driver.FindElement(By.Id("accessid"));

            //Creating connection with database and fetching credentials
             test.Log(Status.Info, "Creating connection with database and fetching credentials");
             string connetionString;
             connetionString = @"Data Source=tcp:wp001.database.windows.net;initial catalog=WP-4444-WorkpulseMarketing;user id=wp001;password=Wp5erver2015";
             SqlConnection cnn;
             cnn = new SqlConnection(connetionString);
             cnn.Open();
             var testData = new DataTable();
             String sql = "SELECT UserName,Password,AccessId FROM MstAutomationEmployee where UserName = 'hemant'";
             var cmd = new SqlCommand(sql, cnn);
             using (var da = new SqlDataAdapter(cmd))
             {
                 da.Fill(testData);
             }
             var resultRows = testData.Select();
             var usernamedata = resultRows[0]["UserName"].ToString();
             var passworddata = resultRows[0]["Password"].ToString();
             var accessiddata = resultRows[0]["AccessId"].ToString();
             username.SendKeys(usernamedata);
             Thread.Sleep(5000);
             password.SendKeys(passworddata);
             Thread.Sleep(5000);
             accessid.SendKeys(accessiddata);
             Thread.Sleep(5000);
             test.Log(Status.Info, "Submitting the login page with Username " + usernamedata);

            /*//Manually sending the credetials to the login page
            username.SendKeys("hemant");
            Thread.Sleep(5000);
            password.SendKeys("Sep@1989");
            Thread.Sleep(5000);
            accessid.SendKeys("4444");
            Thread.Sleep(5000);*/


             IWebElement login = driver.FindElement(By.Id("loginbtn"));
             login.Click();
             test.Log(Status.Info, "Login Successful into the web application");
             Thread.Sleep(5000);
             return driver; 
        }
    }
}



