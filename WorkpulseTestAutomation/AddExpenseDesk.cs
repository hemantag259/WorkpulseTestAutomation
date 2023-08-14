using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;



namespace Workpulse_Project
{

    public class AddExpenseDesk : BaseTest
    {
       
        [Test]
        public void AddExpenseDeskMethod()
        {
            test = null;
            String methodname = TestContext.CurrentContext.Test.MethodName.ToString();
            test = extent.CreateTest(methodname).Info("Adding Expense to the Desk Ticket");
            Dictionary<string, string> headerInfo;
            //String accesstoken = "f25ce5e741bf0bc28010844a6042a0c0";
            String accesstoken;
            accesstoken = BearerToken.GenerateBearerToken();
            test.Log(Status.Info, "Generating the Bearer Token for authorization " +accesstoken);
           
            

            String Bearertokenvalue = "Bearer " + accesstoken;
            var Taskid = APIHelper.GetTaskId(Bearertokenvalue);
            headerInfo = APIHelper.GetHeaderInfo(Bearertokenvalue);
            Random rnd = new Random();
            var amount = rnd.Next(10, 100);
            var endPoint = "https://opsapi.workpulse.com/api/desk/v2/expense?serviceBoardTypeId=1&serviceBoardId=0";
            //string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string path = @"E:\Workpulse documents\Automation\WorkpulseTestAutomation\WorkpulseTestAutomation\Models\AddExpense.json";
            var jsonObject = JObject.Parse(File.ReadAllText(path));
           
           
          
           jsonObject["taskId"] = Taskid;
            jsonObject["amount"]= amount;

            var jsonContent = JsonConvert.SerializeObject(jsonObject);
            var content = new StringContent(jsonContent);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = ServiceHelper.SendRequest(endPoint, headerInfo, HttpMethod.Post, content).Result;
            Assert.IsTrue(response.IsSuccessStatusCode, "POST end point failed while adding a Expense");
            test.Log(Status.Info, "Generation the response");
            try
            {
                test.Log(Status.Pass, "Test Passed");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, "Test Failed");

            }




        }
       
    }
   
}
