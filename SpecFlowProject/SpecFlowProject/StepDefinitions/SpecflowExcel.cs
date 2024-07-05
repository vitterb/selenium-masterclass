namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class SpecflowExcel
    {
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            Console.WriteLine("Adding the values");
        }

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            Console.WriteLine("Entering the values");
        }
        [Then(@"The result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            Console.WriteLine("Result is displayed");
        }


    }
}
