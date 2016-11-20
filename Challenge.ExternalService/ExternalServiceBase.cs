using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Challenge.ExternalService
{
    public class ExternalServiceBase
    {
        private readonly HttpClient _client = new HttpClient();

        public ExternalServiceBase()
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Add("Access-Control-Allow-Origin", new[] { "*" });
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public HttpClient Client
        {
            get { return _client; }
        }
    }
}
