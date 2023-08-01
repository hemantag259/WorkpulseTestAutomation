using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Workpulse_Project
{
    public class ServiceHelper
    {
        public static Task<HttpResponseMessage> SendRequest(string uri, Dictionary<string, string> headerInfo, HttpMethod httpMethod, HttpContent content)
        {
            var request = new HttpRequestMessage(httpMethod, uri) { Content = content };

            if (headerInfo != null)
            {
                foreach (var item in headerInfo)
                {
                    request.Headers.Add(item.Key, item.Value);
                }
            }

            using (var client = new HttpClient(new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip
                                         | DecompressionMethods.Deflate
            }))
            {
                client.Timeout = TimeSpan.FromMinutes(4);
                var response = client.SendAsync(request);
                Assert.IsTrue(response.Result.IsSuccessStatusCode, $"Send Request failed with {response.Result.StatusCode} for {httpMethod.Method} Method");
                return response;
            }
        }
    }
}
