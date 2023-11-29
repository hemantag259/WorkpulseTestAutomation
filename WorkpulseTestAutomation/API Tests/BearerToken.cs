using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using OpenQA.Selenium.Internal;
using NUnit.Framework;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Workpulse_Project
{
    public class BearerToken

    {
        

        
        public static string GenerateBearerToken()
        {
            string bearertokenvalue;
        var bearerurl = "https://devlogin.workpulse.com/core/connect/token";
       
        var client = new HttpClient();

            var data = new[]
            {
        new KeyValuePair<string, string>("grant_type", "password"),
        new KeyValuePair<string, string>("client_id", "app.WorkpulseAudit"),
        new KeyValuePair<string, string>("client_secret","rwVj4Kt6vEFMVWQ2"),
        new KeyValuePair<string, string>("scope", "workpulseApi"),
        new KeyValuePair<string, string>("acr_values", "tenant:1111"),
        new KeyValuePair<string, string>("username", "hemant"),
        new KeyValuePair<string, string>("password","Sep@1989"),

    };
            var response = client.PostAsync(bearerurl, new FormUrlEncodedContent(data)).GetAwaiter().GetResult();
           string responsedata = response.Content.ReadAsStringAsync().Result;
            var objects = JObject.Parse(responsedata);
            bearertokenvalue = (string)objects["access_token"];
            return bearertokenvalue;
        }
    }
            




        }
    


