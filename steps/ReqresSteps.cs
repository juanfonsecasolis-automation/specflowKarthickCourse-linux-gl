using TechTalk.SpecFlow;
using NUnit.Framework;
using karthickSpecflowCourse_linux_gl.models;
using Newtonsoft.Json.Linq;
using System.Net;

namespace karthickSpecflowCourse_linux_gl.steps
{
    [Binding]
    public class ReqresSteps : StepsBase
    {
        Reqres _reqres;
        JObject _peoplePage;

        [Given("I invoke a GET request on Reqres")]
        public void IInvokeAGetRequestOnReqres()
        {
            HttpStatusCode statusCode;
            _reqres = new Reqres();
            (statusCode, _peoplePage) = _reqres.GetPageOfPeople(1);

            Assert.AreEqual(HttpStatusCode.OK, statusCode);
        }

        [When("I count the number of people returned")]
        public void ICountTheNumberOfPeopleReturned()
        {
            JArray arrayOfPeople = (JArray) _peoplePage["data"];
            _bag[BagItems.currentValue] = arrayOfPeople.Count;
        }

        [Then("the counter matches with property \"(.*)\"")]
        public void TheCounterMatchesWithProperty(int propertyName)
        {
            int expectedValue = _peoplePage[propertyName].Value<int>();
            Assert.AreEqual(expectedValue, (int)_bag[BagItems.currentValue]);
        }
    }
}