using TechTalk.SpecFlow.Assist;

namespace SpecFlowBasics.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            Console.WriteLine($"{nameof(GivenTheFirstNumberIs)} :{number}");
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            Console.WriteLine($"{nameof(GivenTheSecondNumberIs)} :{number}");
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            Console.WriteLine($"{nameof(WhenTheTwoNumbersAreAdded)}");
        }

        [Then(@"the result should be ""([^""]*)""")]
        public void ThenTheResultShouldBe(string result)
        {
            Console.WriteLine($"{nameof(ThenTheResultShouldBe)}");
        }

        [Given(@"I input following numbers to the Calculator")]
        public void GivenIInputFollowingNumbersToTheCalculator(Table table)
        {
            dynamic data = table.CreateDynamicSet();
            foreach (var item in data)
            {
                Console.WriteLine($"The Number is {item.Numbers}");
            }
        }
        [Then(@"I see the result and a few more Details")]
        public void ThenISeeTheResultAndAFewMoreDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            Console.WriteLine($"The Result is {data.Result} with logo {data.Logo}.");
        }

    }
}