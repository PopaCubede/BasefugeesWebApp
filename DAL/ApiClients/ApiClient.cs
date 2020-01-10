using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BasefugeesWebApp.Controllers;
using Newtonsoft.Json;

namespace BasefugeesWebApp.DAL.ApiClients
{
    public partial class ApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(Uri baseEndpoint)
        {
            if (baseEndpoint == null) throw new ArgumentNullException("baseEndpoint");
            BaseEndpoint = baseEndpoint;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = BaseEndpoint;
        }

        private Uri BaseEndpoint { get; }

        private static JsonSerializerSettings MicrosoftDateFormatSettings =>
            new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
            };

        /// <summary>
        ///     Common method for making GET calls
        /// </summary>
        private async Task<T> GetAsync<T>(string requestUrl)
        {
            AddHeaders();
            var response = await _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }
        private async Task<T> GetAsyncAnon<T>(string requestUrl)
        {
            AddHeadersAnon();
            var response = await _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }

        /// <summary>
        ///     Common method for making POST calls
        /// </summary>
        /// With SAME type as in and out
        private async Task<T> PostAsync<T>(Uri requestUrl, T content)
        {
            AddHeaders();
            var response = await _httpClient.PostAsync(requestUrl.ToString(), CreateHttpContent(content));
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }
        private async Task<T> PostAsync<T>(string requestUrl, T content)
        {
            AddHeaders();
            var response = await _httpClient.PostAsync(requestUrl, CreateHttpContent(content));
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }
        private async Task<T> PostAsyncAnon<T>(string requestUrl, T content)
        {
            AddHeadersAnon();
            var response = await _httpClient.PostAsync(requestUrl, CreateHttpContent(content));
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }

        // With DIFFERENT type as in and out
        private async Task<T1> PostAsync<T1, T2>(Uri requestUrl, T2 content)
        {
            AddHeaders();
            var response = await _httpClient.PostAsync(requestUrl.ToString(), CreateHttpContent(content));
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T1>(data);
        }
        private async Task<T1> PostAsync<T1, T2>(string requestUrl, T2 content)
        {
            AddHeaders();
            var response = await _httpClient.PostAsync(requestUrl, CreateHttpContent(content));
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T1>(data);
        }
        private async Task<T1> PostAsyncAnon<T1, T2>(string requestUrl, T2 content)
        {
            AddHeadersAnon();
            var response = await _httpClient.PostAsync(requestUrl, CreateHttpContent(content));
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T1>(data);
        }

        private Uri CreateRequestUri(string relativePath, string queryString = "")
        {
            var endpoint = new Uri(BaseEndpoint, relativePath);
            var uriBuilder = new UriBuilder(endpoint);
            uriBuilder.Query = queryString;
            return uriBuilder.Uri;
        }
        private async Task<T> PatchAsync<T>(string requestUrl, T content)
        {
            AddHeaders();
            var response = await _httpClient.PatchAsync(requestUrl, CreateHttpContent(content));
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }

        private HttpContent CreateHttpContent<T>(T content)
        {
            var json = JsonConvert.SerializeObject(content, MicrosoftDateFormatSettings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private void AddHeaders()
        {
            var token = "";

            if (AccountController.EncryptedStorage != null)
            {
                var store = AccountController.EncryptedStorage;
                token = store.Get<string>("user-token");
            }

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Remove("Authorization");
            _httpClient.DefaultRequestHeaders.Add("Authorization",
                "Bearer " + token);
        }

        private void AddHeadersAnon()
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async Task<T> GetAsyncFeatured<T>(string requestUrl)
        {
            ForceHeaders();
            var response = await _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }

        private void ForceHeaders()
        {
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyIjp7ImVtYWlsIjoidGVzdEBlbWFpbC5jb20ifSwiaWF0IjoxNTM3ODAzODQ5fQ.WUShQiHt_OfUnUtscedgQqN9wWYjshEJNXIJTGu7CQc";

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Remove("Authorization");
            _httpClient.DefaultRequestHeaders.Add("Authorization",
                "Bearer " + token);
        }
    }
}
