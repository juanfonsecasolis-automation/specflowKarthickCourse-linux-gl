using karthickSpecflowCourse_linux_gl.Hooks;
using TechTalk.SpecFlow;

namespace karthickSpecflowCourse_linux_gl.steps
{
    [Binding]
    public class StepsBase
    {
        protected SharedSettings _sharedSettings;
        protected ScenarioContext _scenarioContext;

        public static class Keys{
            public const string response = "response";
            public const string statusCode = "statusCode";
            public const string currentValue = "currentValue";
            public const string expectedValue = "expectedValue";
        }

        public StepsBase(SharedSettings sharedSettings, ScenarioContext scenarioContext){
            _sharedSettings = sharedSettings;
            _scenarioContext = scenarioContext;
        }
    }
}