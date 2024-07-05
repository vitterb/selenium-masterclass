using TechTalk.SpecFlow;

namespace SpecFlowBasics.Hooks
{
    [Binding]
    public sealed class TestInitialize
    {
        [BeforeTestRun]
        public static void BeforeTest() => Console.WriteLine("This line is executed before test.");
        
        [BeforeFeature]
        public static void BeforeFeatureTest() => Console.WriteLine("This line is executed before feature.");

        [BeforeScenario("mytag")]
        public void BeforeScenarioWithTag() => Console.WriteLine("This line is executed from before scenario with tag.");

        [AfterScenario]
        public void AfterScenario() => Console.WriteLine("This line is executed after scenario.");
    }
}