using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using WorkpulseTestAutomation.Common;

namespace Workpulse_Project
{

    public class AddDeskTicketandExpense : BaseTest
    {
       
        [Test]
        public void AddDeskMethod()
        {
            test = null;
            String methodname = TestContext.CurrentContext.Test.MethodName.ToString();
            test = extent.CreateTest(methodname).Info("Adding a ticket and Expense to the Desk Ticket");
            Dictionary<string, string> headerInfo;
            //String accesstoken = "f25ce5e741bf0bc28010844a6042a0c0";
            String accesstoken;
            accesstoken = BearerToken.GenerateBearerToken();
            test.Log(Status.Info, "Generating the Bearer Token for authorization " +accesstoken);
           
            

            String Bearertokenvalue = "Bearer " + accesstoken;
            headerInfo = APIHelper.GetHeaderInfo(Bearertokenvalue);

            #region Add a ticket to the desk

            var addticketendpoint = "https://opsapi.workpulse.com/api/desk/ticket";
            string addticketpath = @"E:\Workpulse documents\Automation\WorkpulseTestAutomation\WorkpulseTestAutomation\Models\AddDeskTicket.json";
            var addticketjsonObject = JObject.Parse(File.ReadAllText(addticketpath));
            var addticketjsonContent = JsonConvert.SerializeObject(addticketjsonObject);
            var addticketcontent = new StringContent(addticketjsonContent);

            addticketcontent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var addticketresponse = ServiceHelper.SendRequest(addticketendpoint, headerInfo, HttpMethod.Post, addticketcontent).Result;
            Assert.IsTrue(addticketresponse.IsSuccessStatusCode, "POST end point failed while adding a Desk Ticket");
            #endregion


            #region Add a expense to the Task in Desk
            var Taskid = APIHelper.GetTaskId(Bearertokenvalue);
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
            #endregion




        }

    }
   
}
