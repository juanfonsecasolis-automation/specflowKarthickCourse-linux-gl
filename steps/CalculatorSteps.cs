using TechTalk.SpecFlow;
using NUnit.Framework;
using karthickSpecflowCourse_linux_gl.models;
using karthickSpecflowCourse_linux_gl.Hooks;

namespace karthickSpecflowCourse_linux_gl.steps
{
  [Binding]
  public class CalculatorSteps : StepsBase
  {
        Calculator _calculator;

        public CalculatorSteps(SharedSettings sharedSettings) : base(sharedSettings){
            _calculator = new Calculator();
        }

        [Given("I have entered \"(.*)\" into the calculator")]
        public void GivenIHaveEnteredSomethingIntoTheCalculator(int number)
        {
            _calculator.enterNumber(number);
        }

        [When("I press add")]
        public void WhenIPressAdd()
        {
            _calculator.sumAllNumbers();
        }

        [Then("the result should be \"(.*)\" on the screen")]
        public void ThenTheResultShouldBe(int result)
        {
            Assert.AreEqual(_calculator.getLastResult(), result, 
            $"Obtained result differs from expected: {_calculator.getLastResult()} != {result}");
        }
  }
}