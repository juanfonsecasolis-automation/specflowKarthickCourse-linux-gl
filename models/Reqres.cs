using System.Net;
using System.Text.Json;
using karthickSpecflowCourse_linux_gl.Hooks;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;

namespace karthickSpecflowCourse_linux_gl.models
{
    public class Reqres : APIHandler
    {
        public Reqres(SharedSettings sharedSettings)
            :base(sharedSettings.config["reqresUrl"]){}

        public (HttpStatusCode, JObject) GetPageOfPeople(int pageNumber){
            return ExecuteGetRequest($"/api/users?page={pageNumber}");
        }
    }
}