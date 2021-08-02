using TechTalk.SpecFlow;
using NUnit.Framework;
using karthickSpecflowCourse_linux_gl.models;
using Newtonsoft.Json.Linq;
using System.Net;
using karthickSpecflowCourse_linux_gl.Hooks;

namespace karthickSpecflowCourse_linux_gl.steps
{
    [Binding]
    public class ReqresSteps : StepsBase
    {
        Reqres _reqres;
        ReqresPage _reqresPage;

        public ReqresSteps(SharedSettings sharedSettings) : base(sharedSettings){
            _reqres = new Reqres(sharedSettings);
        }

        [Given("I invoke a GET request on the /users endpoint")]
        public void IInvokeAGetRequestOnTheUsersEndpoint()
        {
            (_sharedSettings.statusCode, _reqresPage) = 
                _reqres.GetPageOfPeople(1);
        }

        [Then("the number of records matches the property \"per_page\"")]
        public void TheNumberOfRecordsMatchesThePropertyPerPage()
        {
            Assert.AreEqual(_reqresPage.per_page, _reqresPage.people.Count);
        }

        [Then("the response contains a non-null field \"(.*)\" for user \"(.*)\"")]
        public void ThenTheResponseContainsANonNullField(string fieldName, int userId){
            switch(fieldName){
                case "id": 
                    Assert.NotNull(_reqresPage.people[userId].id);  
                    break;  
                case "email": 
                    Assert.NotNull(_reqresPage.people[userId].email);  
                    break;  
                case "first_name": 
                    Assert.NotNull(_reqresPage.people[userId].first_name);  
                    break;  
                case "last_name": 
                    Assert.NotNull(_reqresPage.people[userId].last_name);  
                    break;  
                case "avatar": 
                    Assert.NotNull(_reqresPage.people[userId].avatar);  
                    break;  
            }
        }
    }
}