using System.Net;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WS
{
    public class ClientWebService
    {

        public async Task<HttpResponseMessage> SendRequest(HttpMethod httpMethod, string apiRoute, List<KeyValuePair<string, string>> parameters = null, string jsonBody = null, List<KeyValuePair<string, string>> headers = null)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            string requestRoute = AddUrlParameters(parameters, apiRoute);
            var request = new HttpRequestMessage(httpMethod, requestRoute);
            try
            {


                if (headers != null && headers.Count > 0)
                {
                    foreach (var header in headers)
                        request.Headers.Add(header.Key, header.Value);
                }

                if (jsonBody != null)
                {
                    request.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                }
                using (var httpClient = new HttpClient())
                {
                   response = await httpClient.SendAsync(request);
                }

            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            return response;
        }


        private string AddUrlParameters(List<KeyValuePair<string, string>> parameters, string apiRoute)
        {
            if (parameters != null && parameters.Count > 0)
            {
                apiRoute = apiRoute + "?";

                for (int i = 0; i < parameters.Count; i++)
                {
                    var parameter = parameters[i];

                    if (i == 0)
                        apiRoute = apiRoute + parameter.Key + "=" + parameter.Value;
                    else
                        apiRoute = apiRoute + "&" + parameter.Key + "=" + parameter.Value;
                }
            }

            return apiRoute;
        }
    }
}

