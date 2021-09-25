using System.Net;
using System.Threading.Tasks;
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

        public async Task<(HttpStatusCode, JObject)> ExecuteGetRequestAsync(string endpoint){
            var request = new RestRequest(endpoint, Method.GET);
            IRestResponse response = await _client.ExecuteAsync(request);
            return (response.StatusCode, JObject.Parse(response.Content));
        }

        public (HttpStatusCode, JObject) ExecutePostRequest(string endpoint, object body){
            var request = new RestRequest(endpoint, Method.POST);
            request.AddJsonBody(body);
            var response = _client.Execute(request);
            return (response.StatusCode, JObject.Parse(response.Content));
        }

        public HttpStatusCode ExecuteDeleteRequest(string endpoint){
            var request = new RestRequest(endpoint, Method.DELETE);
            var response = _client.Execute(request);
            return response.StatusCode;
        }
    }
}