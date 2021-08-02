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

        public ReqresSteps(SharedSettings sharedSettings) : base(sharedSettings){
            _reqres = new Reqres(sharedSettings);
        }

        [Given("I invoke a GET request on the /users endpoint")]
        public void IInvokeAGetRequestOnTheUsersEndpoint()
        {
            (_sharedSettings.statusCode, _sharedSettings.response) = 
                _reqres.GetPageOfPeople(1);
        }

        [Then("the number of records matches the property \"per_page\"")]
        public void TheNumberOfRecordsMatchesThePropertyPerPage()
        {
            _sharedSettings.expectedValue = _sharedSettings.response["per_page"].Value<int>();
            JArray arrayOfPeople = (JArray) _sharedSettings.response["data"];
            _sharedSettings.currentValue = arrayOfPeople.Count;
            Assert.AreEqual(_sharedSettings.expectedValue, _sharedSettings.currentValue);
 
        }
    }
}