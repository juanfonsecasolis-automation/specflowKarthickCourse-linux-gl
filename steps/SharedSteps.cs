using karthickSpecflowCourse_linux_gl.Hooks;
using TechTalk.SpecFlow;
using NUnit.Framework;
[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace karthickSpecflowCourse_linux_gl.steps
{
    [Binding]
    public class APISteps : StepsBase
    {
        public APISteps(SharedSettings sharedSettings, ScenarioContext scenarioContext) : base(sharedSettings, scenarioContext){}

        [When("the status code is \"(.*)\"")]
        public void WhenTheStatusCodeIs(int expectedCode){
            Assert.AreEqual(expectedCode, (int) _scenarioContext[Keys.statusCode]);
        }

        [Then("the status code is \"(.*)\"")]
        public void ThenTheStatusCodeIs(int expectedCode){
            Assert.AreEqual(expectedCode, (int) _scenarioContext[Keys.statusCode]);
        }
        
    }
}