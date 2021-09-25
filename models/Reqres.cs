using System.Net;
using System.Threading.Tasks;
using karthickSpecflowCourse_linux_gl.Hooks;
using Newtonsoft.Json.Linq;

namespace karthickSpecflowCourse_linux_gl.models
{
    public class Reqres : APIHandler
    {
        public Reqres(SharedSettings sharedSettings)
            :base(sharedSettings.reqresUrl){}

        public (HttpStatusCode, ReqresPage) GetPageOfPeople(string pageNumber){
            HttpStatusCode statusCode; 
            JObject jObject; 
            (statusCode, jObject) = ExecuteGetRequest($"/api/users?page={pageNumber}");
            return (statusCode, new ReqresPage(jObject));
        }

        public async Task<(HttpStatusCode, ReqresPage)> GetPageOfPeopleAsync(string pageNumber){
            HttpStatusCode statusCode; 
            JObject jObject; 
            (statusCode, jObject) = await ExecuteGetRequestAsync($"/api/users?delay={5}&page={pageNumber}");
            return (statusCode, new ReqresPage(jObject));
        }

        public (HttpStatusCode, JObject) GetPerson(int userId){
            HttpStatusCode statusCode; 
            JObject jObject; 
            (statusCode, jObject) = ExecuteGetRequest($"/api/users/{userId}");
            return (statusCode, jObject);
        }

        internal (HttpStatusCode, JObject) CreateNewPerson(string theName, string theJob)
        {        
            return ExecutePostRequest($"/api/users", new {name=theName, job=theJob});
        }

        internal HttpStatusCode DeletePerson(int userId)
        {
            return ExecuteDeleteRequest($"/api/users/{userId}");
        }
    }
}