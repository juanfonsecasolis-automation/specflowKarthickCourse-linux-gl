using TechTalk.SpecFlow;
using NUnit.Framework;
using karthickSpecflowCourse_linux_gl.models;

namespace karthickSpecflowCourse_linux_gl.steps
{
  [Binding]
  public class CalculatorSteps : StepsBase
  {
        Calculator calculator;

        public CalculatorSteps() {
            calculator = new Calculator();
        }

        [Given("I have entered \"(.*)\" into the calculator")]
        public void GivenIHaveEnteredSomethingIntoTheCalculator(int number)
        {
            calculator.enterNumber(number);
        }

        [When("I press add")]
        public void WhenIPressAdd()
        {
            calculator.sumAllNumbers();
        }

        [Then("the result should be \"(.*)\" on the screen")]
        public void ThenTheResultShouldBe(int result)
        {
            Assert.AreEqual(calculator.getLastResult(), result, 
            $"Obtained result differs from expected: {calculator.getLastResult()} != {result}");
        }
  }
}