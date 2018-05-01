using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Solab.Auth0.ManagementApi
{
    public static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> SendAsJsonAsync(this HttpClient client, string httpVerb, string requestUri, object @object, JsonSerializerSettings jsonSerializerSettings = null)
        {
            var jsonString = JsonConvert.SerializeObject(@object, jsonSerializerSettings);

            var content = new StringContent(jsonString, Encoding.UTF8, "application/json"); // setting Content-type

            var request = new HttpRequestMessage(new HttpMethod(httpVerb), requestUri)
            {
                Content = content,
            };

            var response = await client.SendAsync(request);

            return response;
        }

        public static async Task<T> SendAsJsonAsync<T>(this HttpClient client, string httpVerb, string requestUri, object @object, JsonSerializerSettings jsonSerializerSettings = null)
        {
            var response = await SendAsJsonAsync(client, httpVerb, requestUri, @object, jsonSerializerSettings);

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<T>(responseString);
            return result;
        }


        public static Task<HttpResponseMessage> PostAsJsonAsync(this HttpClient client, string requestUri, object @object, JsonSerializerSettings jsonSerializerSettings = null)
        {
            return SendAsJsonAsync(client, "POST", requestUri, @object, jsonSerializerSettings);
        }
        public static Task<T> PostAsJsonAsync<T>(this HttpClient client, string requestUri, object @object, JsonSerializerSettings jsonSerializerSettings = null)
        {
            return SendAsJsonAsync<T>(client, "POST", requestUri, @object, jsonSerializerSettings);
        }


        public static Task<HttpResponseMessage> DeleteAsJsonAsync(this HttpClient client, string requestUri, object @object, JsonSerializerSettings jsonSerializerSettings = null)
        {
            return SendAsJsonAsync(client, "DELETE", requestUri, @object, jsonSerializerSettings);
        }
        public static Task<T> DeleteAsJsonAsync<T>(this HttpClient client, string requestUri, object @object, JsonSerializerSettings jsonSerializerSettings = null)
        {
            return SendAsJsonAsync<T>(client, "DELETE", requestUri, @object, jsonSerializerSettings);
        }


        public static Task<HttpResponseMessage> PatchAsJsonAsync(this HttpClient client, string requestUri, object @object, JsonSerializerSettings jsonSerializerSettings = null)
        {
            return SendAsJsonAsync(client, "PATCH", requestUri, @object, jsonSerializerSettings);
        }
        public static Task<T> PatchAsJsonAsync<T>(this HttpClient client, string requestUri, object @object, JsonSerializerSettings jsonSerializerSettings = null)
        {
            return SendAsJsonAsync<T>(client, "PATCH", requestUri, @object, jsonSerializerSettings);
        }


        public static Task<HttpResponseMessage> PutAsJsonAsync(this HttpClient client, string requestUri, object @object, JsonSerializerSettings jsonSerializerSettings = null)
        {
            return SendAsJsonAsync(client, "PUT", requestUri, @object, jsonSerializerSettings);
        }
        public static Task<T> PutAsJsonAsync<T>(this HttpClient client, string requestUri, object @object, JsonSerializerSettings jsonSerializerSettings = null)
        {
            return SendAsJsonAsync<T>(client, "PUT", requestUri, @object, jsonSerializerSettings);
        }


        public static async Task<T> GetAsJsonAsync<T>(this HttpClient client, string requestUri, JsonSerializerSettings jsonSerializerSettings = null)
        {
            var response = await client.GetAsync(requestUri);

            var resultString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<T>(resultString, jsonSerializerSettings);

            return result;
        }
    }
}
