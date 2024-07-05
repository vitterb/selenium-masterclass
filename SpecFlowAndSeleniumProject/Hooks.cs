using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace SpecFlowAndSeleniumProject
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void Initialize()
        {
            EdgeOptions options = new EdgeOptions();
            options.AddArgument("--headless");
            _driver = new EdgeDriver(options);
            _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
        }

        [AfterScenario]
        public void CleanUp()
        {
            _driver.Quit();
        }
    }
}