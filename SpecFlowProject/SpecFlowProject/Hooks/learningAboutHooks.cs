namespace SpecFlowProject.Hooks
{
    [Binding]
    public sealed class learningAboutHooks
    {
        private readonly ScenarioContext _scenarioContext;
        public learningAboutHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario("@Learning")]
        public void BeforeScenarioWithTag()
        {
            Console.WriteLine("Called before every scenario with tag @Learning");
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            Console.WriteLine("Called before every scenario with order 1");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("Called after every scenario");
            Console.WriteLine("The Scenario: {0}", _scenarioContext.ScenarioInfo.Title);
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            Console.WriteLine("Called before every feature" + featureContext.FeatureInfo.Title);
        }
        [AfterFeature]
        public static void AfterFeature(FeatureContext featureContext)
        {
            Console.WriteLine("Called after every feature" + featureContext.FeatureInfo.Title);
        }
        [AfterStep("@Getting")]
        public void AfterStep()
        {
            var stepInfo = ScenarioContext.Current.StepContext.StepInfo.Text;
            Console.WriteLine("Called after every step");
            Console.WriteLine($"The step info is: {stepInfo}");

        }
    }
}