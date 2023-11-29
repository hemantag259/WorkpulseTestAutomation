using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Microsoft.VisualBasic;

namespace Workpulse_Project
{
    public class APIHelper
    {
        public static Dictionary<string, string> GetHeaderInfo(string BearerToken)
        {
            return new Dictionary<string, string>
            {
                {"Authorization", BearerToken},
                {"Accept-Encoding", "gzip, deflate, br" },
                {"Accept", "application/json, text/plain, */*" }
            };
        }
        
        public static JToken GetTaskId(String BearerToken)
        {
            String endPoint = "https://devapi.workpulse.com/api/desk/v2/ticketlist";
            Dictionary<string, string> headerInfo;
            string path = @"E:\Workpulse documents\Automation\WorkpulseTestAutomation\WorkpulseTestAutomation\Models\TicketList.json";

            //var jsonArray = JArray.Parse(File.ReadAllText(Path.Combine(TestHelper.AssemblyDirectory
            //  ,
            //                      path +  @"\Models\AddExpense.json")))
            //var jsonArray = JArray.Parse(File.ReadAllText(Path.Combine(path, @"Models\AddExpense.json")));
            //var jsonArray = JArray.Parse(File.ReadAllText(path));

            var objects = JObject.Parse(File.ReadAllText(path));
            objects["endDate"] = DateAndTime.Now.ToString("MM/dd/yyyy");
            var jsonContent = JsonConvert.SerializeObject(objects);
            var content = new StringContent(jsonContent);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            headerInfo = APIHelper.GetHeaderInfo(BearerToken);
            var response = ServiceHelper.SendRequest(endPoint, headerInfo, HttpMethod.Post, content).Result;
            
            //var result = ServiceHelper.Post(endPoint, headerInfo);
            var rawData = JObject.Parse(response.Content.ReadAsStringAsync().Result);
           var resultData = (String)rawData["ticketList"][0]["id"].ToString();
            return resultData;
        }
    }
}
