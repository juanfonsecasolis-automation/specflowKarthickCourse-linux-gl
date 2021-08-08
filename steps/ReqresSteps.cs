using TechTalk.SpecFlow;
using NUnit.Framework;
using karthickSpecflowCourse_linux_gl.models;
using Newtonsoft.Json.Linq;
using System.Net;
using karthickSpecflowCourse_linux_gl.Hooks;
using System.Text.RegularExpressions;

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

        [Given("I get the information of user (.*)")]
        public void IInvokeAGetRequestOnTheUsersEndpoint(string userId)
        {
            (_sharedSettings.statusCode, _reqresPage) = 
                _reqres.GetPageOfPeople(userId);
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

        [Then("\"(.*)\" field in response follows regex \"(.*)\" for user \"(.*)\"")]
        public void ThenFieldInResponseFollowsRegexForUser(string fieldName, string regexString, int userId){
            Regex regex = new Regex(regexString);
            TestContext.WriteLine($"Email: '{_reqresPage.people[userId].email}'");
            Assert.True(regex.Match(_reqresPage.people[userId].email).Success);
        }

        [Given("I create a new user with name \"(.*)\" and job \"(.*)\"")]
        public void GivenISendAPostRequestToCreateANewUserWithNameAndJob(string name, string job){
            (_sharedSettings.statusCode, _sharedSettings.response) 
                = _reqres.CreateNewPerson(name, job);
            string id = _sharedSettings.response["id"].Value<string>();
            TestContext.WriteLine($"Saving '{id}'");
            _sharedSettings.lastCreatedReqresId = int.Parse(id);
        }

        [Given("the last created user still exists")]
        public void GivenTheLastCreatedUserStillExists(){
            JObject jObject;
            (_sharedSettings.statusCode, jObject) = 
                _reqres.GetPerson(_sharedSettings.lastCreatedReqresId);
            TestContext.WriteLine($"Data: {jObject.ToString()}");
            Assert.IsNotEmpty(jObject,"User doesn't exist!");
            Assert.Equals(_sharedSettings.lastCreatedReqresId,
                jObject["data"]["id"].Value<int>());
        }

        [When("I delete the last created user")]
        public void WhenIDeleteTheLastCreatedUser(){
            _sharedSettings.statusCode =_reqres.DeletePerson(_sharedSettings.lastCreatedReqresId);
        }
    }
}