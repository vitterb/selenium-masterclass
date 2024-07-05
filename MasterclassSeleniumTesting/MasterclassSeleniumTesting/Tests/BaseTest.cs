using MasterclassSeleniumTesting.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System.Drawing;

namespace MasterclassSeleniumTesting.Pages
{
    public class BaseTest
    {
        private IWebDriver driver;

        protected IWebDriver GetDriver()
        {
            return driver;
        }

        protected void SetDriver(IWebDriver driver)
        {
            this.driver = driver;
        }

        [SetUp]
        public virtual void Setup()
        {
            driver = CreateDriver(ConfigurationProvider.Configuration["browser"]);
            driver.Manage().Window.Size = new Size(1920, 1200);
            driver.Navigate().GoToUrl("http://localhost:5173");
        }

        [TearDown]
        public virtual void Teardown()
        {
            driver.Quit();
        }

        protected IWebDriver CreateDriver(string browser)
        {
            switch (browser.ToLowerInvariant())
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments(GetBrowserArguments());
                    return new ChromeDriver(chromeOptions);

                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddArguments(GetBrowserArguments());
                    return new FirefoxDriver(firefoxOptions);

                case "edge":
                    var edgeOptions = new EdgeOptions();
                    edgeOptions.AddArguments(GetBrowserArguments());
                    return new EdgeDriver(edgeOptions);

                default:
                    throw new Exception("Provided browsername is not supported!");
            }
        }

        public string[] GetBrowserArguments()
        {
            if (ConfigurationProvider.Configuration["browserArguments"] != null)
            {
                return ConfigurationProvider.Configuration["browserArguments"].Split(',');
            }
            else
            {
                return Array.Empty<string>();
            }
        }
    }
}