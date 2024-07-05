using MasterclassSeleniumTesting.Utils;
using OpenQA.Selenium;

namespace MasterclassSeleniumTesting.Pages
{
    internal class CompaniesPage : BasePage
    {
        public CompaniesPage(IWebDriver driver) : base(driver) { }

        private IList<IWebElement> CompanyElements => driver.FindElements(By.ClassName("CompanyName"));
        public IWebElement companyInput => driver.FindElement(By.XPath("//*[@id='companyName']"));
        private IWebElement AddCompanyButton => driver.FindElement(By.Id("addCompany"));
        private IWebElement DeleteButton => driver.FindElement(By.XPath("//*[@id='root']/div/ul/li[3]/ul/button"));
        private IWebElement HomeButton => driver.FindElement(By.LinkText("Home"));
        private IWebElement UsersButton => driver.FindElement(By.LinkText("Users"));
        private IWebElement TimeRegistrationsButton => driver.FindElement(By.LinkText("Time Registrations"));

        public void ClickHomeButton()
        {
            HomeButton.Click();
        }

        public void ClickUsersButton()
        {
            UsersButton.Click();
        }

        public void ClickTimeRegistrationsButton()
        {
            TimeRegistrationsButton.Click();
        }

        public string ReturnCompanyWithIndex(int index)
        {
            return CompanyElements[index].Text;
        }

        public void WaitForCampanyNamesToLoad()
        {
            var wait = new Wait(driver);
            wait.WaitForTheElementToBecomeVisible(By.ClassName("CompanyName"), TimeSpan.FromSeconds(15));
        }

        public void WaitForEmployeeNamesToLoad()
        {
            var wait = new Wait(driver);
            wait.WaitForTheElementToBecomeVisible(By.ClassName("EmployeeName"), TimeSpan.FromSeconds(15));
        }

        public void WaitForTestCompanyToLoad()
        {
            var wait = new Wait(driver);
            wait.WaitForTheElementToBecomeVisible(By.XPath("//*[@id='root']/div/ul/li[3]/div"), TimeSpan.FromSeconds(15));
        }

        public int ReturnEmployeeCountWithIndex(int companyIndex)
        {
            var companyLi = CompanyElements[companyIndex].FindElement(By.XPath("./ancestor::li"));
            var employees = companyLi.FindElements(By.XPath(".//ul/li[.//div[contains(@class, 'title is-5')]]"));
            return employees.Count;
        }

        public string ReturnEmployeeNameWithIndex(int companyIndex, int employeeIndex)
        {
            var companyLi = CompanyElements[companyIndex].FindElement(By.XPath("./ancestor::li"));
            var employees = companyLi.FindElements(By.XPath(".//ul/li[.//div[contains(@class, 'title is-5')]]"));
            string cleanedUpOutput = employees[employeeIndex].Text;
            return CleanString(cleanedUpOutput);
        }

        public void EnterCompanyName(string companyName)
        {
            companyInput.SendKeys(companyName);
        }

        public void ClickAddCompanyButton()
        {
            AddCompanyButton.Click();
        }

        public void ClickOnDeleteButton()
        {
            DeleteButton.Click();
        }

        public string CleanString(string input)
        {
            int index = input.IndexOf("\r");
            if (index > 0)
            {
                return input.Substring(0, index);
            }
            else
            {
                return input;
            }
        }
    }
}