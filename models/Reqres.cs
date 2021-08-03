using System;
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
            :base(sharedSettings.reqresUrl){}

        public (HttpStatusCode, ReqresPage) GetPageOfPeople(int pageNumber){
            HttpStatusCode statusCode; 
            JObject jObject; 
            (statusCode, jObject) = ExecuteGetRequest($"/api/users?page={pageNumber}");
            return (statusCode, new ReqresPage(jObject));
        }

        internal (HttpStatusCode, JObject) CreateNewPerson(string theName, string theJob)
        {        
            return ExecutePostRequest($"/api/users", new {name=theName, job=theJob});
        }

        internal HttpStatusCode DeletePerson(string userId)
        {
            return ExecuteDeleteRequest($"/api/users/{userId}");
        }
    }
}