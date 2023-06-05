using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace WS
{
    public static class RequestMethods
    {
        public async static Task<TResponse> Get<TBody, TResponse>( string apiRoute, List<KeyValuePair<string, string>> parameters = null, TBody body = null, List<KeyValuePair<string, string>> headers = null)
        where TBody : class, new()
        where TResponse : class, new()
        {

            var client = new ClientWebService();
            var response = await client.SendRequest(HttpMethod.Get, apiRoute, parameters, JsonConvert.SerializeObject(body), headers);

            string apiResponse = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TResponse>(apiResponse);
        }

        public async static Task<TResponse> Post<TBody, TResponse>(string apiRoute, List<KeyValuePair<string, string>> parameters = null, TBody body = null, List<KeyValuePair<string, string>> headers = null)
        where TBody : class, new()
        where TResponse : class, new()
        {
            var client = new ClientWebService();
            var response = await client.SendRequest(HttpMethod.Post, apiRoute, parameters, JsonConvert.SerializeObject(body), headers);

            string apiResponse = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TResponse>(apiResponse);
        }

        public async static Task<TResponse> Put<TBody, TResponse>(string apiRoute, List<KeyValuePair<string, string>> parameters = null, TBody body = null, List<KeyValuePair<string, string>> headers = null)
        where TBody : class, new()
        where TResponse : class, new()
        {
            var client = new ClientWebService();
            var response = await client.SendRequest(HttpMethod.Put, apiRoute, parameters, JsonConvert.SerializeObject(body), headers);

            string apiResponse = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TResponse>(apiResponse);
        }

        public async static Task<TResponse> Delete<TBody, TResponse>(string apiRoute, List<KeyValuePair<string, string>> parameters = null, TBody body = null, List<KeyValuePair<string, string>> headers = null)
        where TBody : class, new()
        where TResponse : class, new()
        {
            var client = new ClientWebService();
            var response = await client.SendRequest(HttpMethod.Delete, apiRoute, parameters, JsonConvert.SerializeObject(body), headers);

            string apiResponse = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TResponse>(apiResponse);
        }
    }
}
