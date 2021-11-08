
using System.Collections.Concurrent;
using AventStack.ExtentReports;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace specflowKarthickCourse_linux_gl.Hooks
{
    [Binding]
    public class Hooks
    {
        ScenarioContext ctx;
        ExtentReports extentReports = null;
        ConcurrentDictionary<string, ExtentTest> extendDictionary;

        public Hooks(ScenarioContext ctx){
            this.ctx = ctx;
            extentReports = new ExtentReports();
            //extentReports.AttachReporter(new ExtentSparkReporter("/tmp/index.html"));
            extendDictionary = new ConcurrentDictionary<string, ExtentTest>();

            // add a new feature if it doesn't exist
            extendDictionary["dummy"] = extentReports.CreateTest(new GherkinKeyword("Feature"), "dummy");
        }

        [BeforeScenario]
        void beforeScenario(){
            string scenarioName = ctx.ScenarioInfo.Title;
            TestContext.WriteLine($"Scenario name: {scenarioName}");
            extendDictionary[scenarioName] = extendDictionary["dummy"]
                .CreateNode(new GherkinKeyword("Scenario"), scenarioName);
        }

        [AfterScenario]
        void afterScenario(){
            extentReports.Flush();
        }

        [BeforeStep]
        void beforeStep(){
            string stepName = ctx.StepContext.StepInfo.Text;
            TestContext.WriteLine($"Step name: {stepName}");
        }

        [AfterStep]
        void afterStep(){
            ExtentTest step;
            string scenarioName = ctx.ScenarioInfo.Title;
            string stepName = ctx.StepContext.StepInfo.Text;
            string stepType = ctx.StepContext.StepInfo.StepDefinitionType.ToString();
            step = extendDictionary[scenarioName].CreateNode(new GherkinKeyword(stepType), stepName);
            
            switch(ctx.ScenarioExecutionStatus){
                case ScenarioExecutionStatus.OK:
                    step.Pass("");
                    break;
                case ScenarioExecutionStatus.TestError:
                    step.Fail(ctx.TestError.ToString());
                    break;
                case ScenarioExecutionStatus.StepDefinitionPending:
                    step.Skip("Not implemented");
                    break;
            }
        }
    }
}