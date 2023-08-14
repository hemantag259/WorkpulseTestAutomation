using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Workpulse_Project
{
    public class ServiceHelper
    {

        [ThreadStatic]
        public static HttpRequestMessage _reqMessage;
        [ThreadStatic]
        public static HttpClient _client;
        [ThreadStatic]
        public static HttpConfiguration _configuration;
        [ThreadStatic]
        public static HttpResponseMessage _responseMessage;
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
        public static HttpResponseMessage Get(string Url, Dictionary<string,
            string> headers = null, bool AuthenticationReq = true)
        {
            _configuration = new HttpConfiguration();
            _reqMessage = new HttpRequestMessage(HttpMethod.Get, Url);
            _client = new HttpClient { Timeout = TimeSpan.FromMinutes(5) };

            //common header for all requests
            _reqMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //if headers are pushed then add headers to the request
            if (headers == null || !AuthenticationReq)
                return _client.SendAsync(_reqMessage, HttpCompletionOption.ResponseContentRead, new CancellationToken())
                    .Result;
            foreach (var item in headers)
            {
                _reqMessage.Headers.Add(item.Key, item.Value);
            }
            return _client.SendAsync(_reqMessage, HttpCompletionOption.ResponseContentRead, new CancellationToken()).Result;
        }

        public static HttpResponseMessage PostData<T>(string Url, T bodyParameter, Dictionary<string, string> headers = null, bool AuthenticationReq = true, bool halJsonReq = false)
        {
            Assert.IsNotNull(headers, "Header data not initialized in POST Data API Method");


            _configuration = new HttpConfiguration();
            _reqMessage = new HttpRequestMessage(HttpMethod.Post, Url);
            _client = new HttpClient { Timeout = TimeSpan.FromMinutes(5) };

            //common header for all requests
            if (halJsonReq)
            {
                _reqMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
                _reqMessage.Content = new ObjectContent<T>(bodyParameter, new JsonMediaTypeFormatter());
            }
            else
            {
                _reqMessage.Content = new ObjectContent<T>(bodyParameter, new JsonMediaTypeFormatter(), "application/json");
            }


            //if headers are pushed then add headers to the request
            if (headers != null && AuthenticationReq)
            {
                foreach (var item in headers)
                {
                    _reqMessage.Headers.Add(item.Key, item.Value);
                    //_log.Debug($"Headers Info for POST Message is : {item.Key} {item.Value}");
                }
            }

            return _client.SendAsync(_reqMessage, HttpCompletionOption.ResponseContentRead, new CancellationToken()).Result;

        }
        public static HttpResponseMessage Post(string Url, Dictionary<string,
            string> headers = null, bool AuthenticationReq = true)
        {
            _configuration = new HttpConfiguration();
            _reqMessage = new HttpRequestMessage(HttpMethod.Post, Url);
            _client = new HttpClient { Timeout = TimeSpan.FromMinutes(5) };

            //common header for all requests
            _reqMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
           

            //if headers are pushed then add headers to the request
            if (headers == null || !AuthenticationReq)
                return _client.SendAsync(_reqMessage, HttpCompletionOption.ResponseContentRead, new CancellationToken())
                    .Result;
            foreach (var item in headers)
            {
                _reqMessage.Headers.Add(item.Key, item.Value);
            }
            return _client.SendAsync(_reqMessage, HttpCompletionOption.ResponseContentRead, new CancellationToken()).Result;
        }

    }
}
