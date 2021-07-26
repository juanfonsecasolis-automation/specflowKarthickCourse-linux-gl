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
        JObject _peoplePage;
        public ReqresSteps(SharedSettings sharedSettings) : base(sharedSettings){
            _reqres = new Reqres(sharedSettings);
        }

        [Given("I invoke a GET request on Reqres")]
        public void IInvokeAGetRequestOnReqres()
        {
            HttpStatusCode statusCode;
            (statusCode, _peoplePage) = _reqres.GetPageOfPeople(1);
            _sharedSettings.statusCode = statusCode;
        }

        [When("I count the number of people returned")]
        public void ICountTheNumberOfPeopleReturned()
        {
            JArray arrayOfPeople = (JArray) _peoplePage["data"];
            _sharedSettings.currentValue = arrayOfPeople.Count;
            TestContext.WriteLine($"Current value: {arrayOfPeople.Count}");
        }

        [Then("the counter matches with property \"(.*)\"")]
        public void TheCounterMatchesWithProperty(string propertyName)
        {
            int expectedValue = _peoplePage[propertyName].Value<int>();
            TestContext.WriteLine($"Expected value: {expectedValue}");
            Assert.AreEqual(expectedValue, _sharedSettings.currentValue);
        }
    }
}