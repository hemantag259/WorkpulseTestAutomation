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
using WorkpulseTestAutomation.Common;
using OpenQA.Selenium.Interactions;
using NUnit.Framework.Internal;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Xml.Linq;

namespace Workpulse_Project
{
    [TestFixture]
    public class Admin : BaseTest
    {
        IWebDriver driver;
        
       
        [Test]
        public void verifyBookTaskCreation()

        {
            driver = Login.LoginWorkpulse();
            Thread.Sleep(5000);
            IWebElement allapp = driver.FindElement(By.Id("myapps-tab"));
            allapp.Click();
            test.Log(Status.Info, "Clicking on My App tabs");
            IWebElement adminapp = driver.FindElement(By.XPath("//*[@id=\"my-apps-row\"]/a[15]/div/div[2]/div/div[1]"));
            adminapp.Click();
            test.Log(Status.Info, "Clicking on Admin app");
            Thread.Sleep(5000);
            Actions actions = new Actions(driver);
            IWebElement bookmenu = driver.FindElement(By.LinkText("Book"));
            actions.MoveToElement(bookmenu).Perform();
            Thread.Sleep(5000);
            IWebElement booktask = driver.FindElement(By.XPath("//*[@id=\"sidebarDevops\"]/li[9]/a/span[2]/i"));
            booktask.Click();
            test.Log(Status.Info, "Clicking on the Book Task Link to navigate to the Book Tasks screen");
            Thread.Sleep(5000);
            IWebElement booktasklink = driver.FindElement(By.LinkText("Book Tasks"));
            booktasklink.Click();
            Thread.Sleep(5000);
            driver.SwitchTo().Frame(driver.FindElement(By.Id("webViewFrame")));
            Thread.Sleep(5000);
            IWebElement addtaskname = driver.FindElement(By.XPath("//*[@id=\"bookTaskWebView\"]/div[1]/div[1]/table/tbody/tr/td[1]/div/button"));
            addtaskname.Click();
            test.Log(Status.Info, "Clicking on the Add Task button to create new task");
            Thread.Sleep(5000);
            IWebElement taskname = driver.FindElement(By.Name("taskName"));
            Random rnd = new Random();
            var value = rnd.Next(100, 1000);
            var taskvalue = "AutomationTask_" + value;
            taskname.SendKeys(taskvalue);
            test.Log(Status.Info, "Creating the Book task with name " + taskvalue);
            Thread.Sleep(5000);
            SelectElement category = new SelectElement(driver.FindElement(By.Id("drpCategory")));
            category.SelectByIndex(2);
            test.Log(Status.Info, "Selecting the Cold Holding Category");
            Thread.Sleep(5000);
            IWebElement question = driver.FindElement(By.XPath("//*[@class = 'btnQuestion button-height']"));
            question.Click();
            test.Log(Status.Info, "Clicking on the Add Question button");
            Thread.Sleep(5000);
            IWebElement questionselection = driver.FindElement(By.XPath("//*[@class = 'form-control input-width dropdown-height']"));
            questionselection.Click();
            Thread.Sleep(5000);
            IWebElement questionclick = driver.FindElement(By.XPath("//*[@class = 'form-check-label ng-binding']"));
            questionclick.Click();
            test.Log(Status.Info, "Selecting the Question from the list");
            Thread.Sleep(5000);
            IWebElement questiontype = driver.FindElement(By.XPath("//md-select[@id='select_9']"));
            questiontype.Click();
            Thread.Sleep(5000);
            IWebElement questiontypeselect = driver.FindElement(By.Id("select_option_76"));
            questiontypeselect.Click();
            test.Log(Status.Info, "Selecting the Temparature type Question from the list");
            Thread.Sleep(5000);
            IWebElement savebutton = driver.FindElement(By.XPath("//button[@class='btn btn-save waves-effect waves-light']"));
            savebutton.Click();
            test.Log(Status.Info, "Saving the data from Add Question pop up");
            Thread.Sleep(5000);
            IWebElement schedule = driver.FindElement(By.XPath("//button[@class= 'btnSave button-height schedule-margin sch-button-width pointer-curser']"));
            schedule.Click();
            test.Log(Status.Info, "Clicking on the Schedule option for creating the schedule");
            Thread.Sleep(5000); 
            IWebElement checkbox = driver.FindElement(By.XPath("(//*[@id=\"chkOverrideSchedule\"])[3]"));
            checkbox.Click();
            test.Log(Status.Info, "Enabling the Schedule from the checkbox");
            Thread.Sleep(5000);
            IWebElement saveschedulebutton = driver.FindElement(By.XPath("(//*[@class= 'btn btn-save waves-effect waves-light'])[2]"));
            saveschedulebutton.Click();
            test.Log(Status.Info, "Saving the defined Schedule");
            Thread.Sleep(5000);
            IWebElement saveallbutton = driver.FindElement(By.XPath("//*[@class = 'btnSave enablebtn']"));
            saveallbutton.Click();
            test.Log(Status.Info, "Creation of the task on the Book Tasks screen Succesfully with name " + taskvalue);
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