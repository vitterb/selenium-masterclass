using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowAndSeleniumProject.Pages
{
    internal class BasePage
    {
        protected IWebDriver _driver;
        protected WebDriverWait _wait;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        // IWebElements

        private IWebElement HomeLink => _driver.FindElement(By.LinkText("Home"));
        private IWebElement Companylink => _driver.FindElement(By.LinkText("Companies"));
        private IWebElement Userlink => _driver.FindElement(By.LinkText("Users"));
        private IWebElement TimeRegistrationlink => _driver.FindElement(By.LinkText("Time Registrations"));
        private IWebElement TitleElement => _driver.FindElement(By.Id("title"));

        // Methodes
        public void GoToHomePage() => _driver.Navigate().GoToUrl("http://localhost:5173");

        public void GoToUserPage() => _driver.Navigate().GoToUrl("http://localhost:5173/users");

        public void GoToCompanyPage() => _driver.Navigate().GoToUrl("http://localhost:5173/companies");

        public string GetCurrentUrl() => _driver.Url;

        public void ClickUserLink() => Userlink.Click();

        public void ClickCompanyLink() => Companylink.Click();

        public void ClickTimeRegistrationLink() => TimeRegistrationlink.Click();

        public void ClickHomeLink() => HomeLink.Click();

        public string GetTitle() => TitleElement.Text;
    }
}