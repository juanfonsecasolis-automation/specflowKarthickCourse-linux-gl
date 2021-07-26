using System.Net;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace karthickSpecflowCourse_linux_gl.models
{
    public class APIHandler
    {
        RestClient _client;
        public APIHandler(string baseUrl){
            _client = new RestClient(baseUrl);
        }

        public (HttpStatusCode, JObject) ExecuteGetRequest(string endpoint){
            var request = new RestRequest(endpoint, Method.GET);
            var response = _client.Execute(request);
            return (response.StatusCode, JObject.Parse(response.Content));
        }
    }
}