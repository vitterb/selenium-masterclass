using OpenQA.Selenium;

namespace MasterclassSeleniumTesting.Pages
{
    internal class Homepage : BasePage
    {
        public Homepage(IWebDriver driver) : base(driver) { }

        //IWebElements
        private IWebElement UsersLink => driver.FindElement(By.Id("users"));

        private IWebElement CompaniesLink => driver.FindElement(By.LinkText("Companies"));
        private IWebElement TimeRegistrations => driver.FindElement(By.Id("timeRegistrations"));

        //Methods
        public void ClickUsersLink()
        {
            UsersLink.Click();
        }

        public void ClickCompaniesLink()
        {
            CompaniesLink.Click();
        }

        public void ClickTimeRegistrationsLink()
        {
            TimeRegistrations.Click();
        }
    }
}