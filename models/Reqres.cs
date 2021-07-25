using System.Net;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace karthickSpecflowCourse_linux_gl.models
{
    public class Reqres
    {
        RestClient _client;
        public Reqres(){
            _client = new RestClient("https://reqres.in");
        }

        public (HttpStatusCode, JObject) GetPageOfPeople(int pageNumber){
            var request = new RestRequest(
                "https://reqres.in/api/users?page={pageNumber}", Method.GET);
            request.AddUrlSegment("pageNumber", pageNumber);
            var response = _client.Execute(request);
            return (response.StatusCode, 
                JsonSerializer.Deserialize<JObject>(response.Content));
        }
    }
}