using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.IO;
using System.Data.Sql;
using NUnit.Framework.Interfaces;
using System.Data;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using RazorEngine.Compilation.ImpromptuInterface;
using WorkpulseTestAutomation;

namespace Workpulse_Project
{
    [TestFixture]
    public class Admin : BaseTest
    {
        IWebDriver driver;
        
       
        [Test]
        public void verifyAdmin()

        {
            driver = Login.LoginWorkpulse();
            IWebElement allapp = driver.FindElement(By.Id("myapps-tab"));
            allapp.Click();
            IWebElement adminapp = driver.FindElement(By.XPath("//*[@id=\"my-apps-row\"]/a[15]/div/div[2]/div/div[1]"));
            adminapp.Click();
            Thread.Sleep(5000);
            try
            {
                test.Log(Status.Pass, "Test Passed");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, "Test Failed");

            }
        }
        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }

      
    }
}