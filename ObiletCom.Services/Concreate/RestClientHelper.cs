using Newtonsoft.Json;
using ObiletCom.Domain.Helpers;
using ObiletCom.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ObiletCom.Services.Concreate
{
    public class RestClientHelper : IRestClientHelper
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public RestClientHelper(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<Response<T>> ExecuteReqeust<T>(string requestUri, HttpMethod httpMethod, object postData = null, Dictionary<string, string> headers = null, Dictionary<string, string> parameters = null, string stringPostData = null)
        {
            string response = string.Empty;
            HttpClient httpClient = _httpClientFactory.CreateClient();

            requestUri = AddParameters(requestUri, parameters);
            AddHeaders(httpClient, headers);
            httpClient.BaseAddress = new Uri(requestUri);
            // Http Get Kullanılırsa buradan erişilebilir
            if (httpMethod == HttpMethod.Get)
                response = await httpClient.GetAsync(requestUri).Result.Content.ReadAsStringAsync();
            else if (httpMethod == HttpMethod.Post)
            {
                if (postData == null)
                {
                    response = await httpClient.PostAsync(requestUri, new StringContent(stringPostData, Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync();
                }
                else
                {
                    var serializePostData = JsonConvert.SerializeObject(postData, Newtonsoft.Json.Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                    response = await httpClient.PostAsync(requestUri, new StringContent(serializePostData, Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync();
                }
            }
            else
                return new Response<T> (false, "Invalid HttpMethod");

            var serializedResult = JsonConvert.DeserializeObject<T>(response);
            return new Response<T>(true, serializedResult);
        }
        private string AddParameters(string requestUri, Dictionary<string, string> parameters)
        {
            if (parameters == null)
                return requestUri;

            var strParam = string.Join("&", parameters.Select(p => p.Key + "=" + p.Value));
            return string.Concat(requestUri, '?', strParam);

        }
        private void AddHeaders(HttpClient httpClient, Dictionary<string, string> headers, string acceptHeader = "application/json")
        {
            httpClient.DefaultRequestHeaders.Add("Accept", acceptHeader);
            if (headers == null)
                return;

            foreach (KeyValuePair<string, string> current in headers)
                httpClient.DefaultRequestHeaders.Add(current.Key, current.Value);
        }
    }
}
