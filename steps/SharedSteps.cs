using System.Net;
using karthickSpecflowCourse_linux_gl.Hooks;
using karthickSpecflowCourse_linux_gl.models;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace karthickSpecflowCourse_linux_gl.steps
{
    [Binding]
    public class APISteps : StepsBase
    {
        public APISteps(SharedSettings sharedSettings) : base(sharedSettings){}

        [When("the status code is OK")]
        public void WhenTheStatusCodeIsOk(){
            Assert.AreEqual(HttpStatusCode.OK, _sharedSettings.statusCode);
        }
        
    }
}