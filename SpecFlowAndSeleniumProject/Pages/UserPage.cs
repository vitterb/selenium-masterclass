using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SpecFlowAndSeleniumProject.Pages
{
    internal class UserPage : BasePage
    {
        public UserPage(IWebDriver driver) : base(driver)
        {
        }

        // IWebElements
        private IWebElement UserNameField => _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("userName")));

        private IWebElement UserNameUpdateField => _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("editedUserName")));
        private IWebElement CompanySelection => _driver.FindElement(By.Id("companyId"));
        private SelectElement CompanySelectionElement => new SelectElement(CompanySelection);
        private IWebElement Addbutton => _driver.FindElement(By.XPath("//*[@id='root']/div/div[2]/div/form/table/tbody/tr[5]/td/button"));

        private IWebElement? GetUserRowByName(string userName)
        {
            return _wait.Until(driver => driver.FindElements(By.CssSelector(".UserNames")).FirstOrDefault(e => e.Text.Trim() == userName));
        }

        private string? GetCompanyByUserRow(IWebElement userRow)
        {
            var parentLi = userRow.FindElement(By.XPath("./ancestor::li[1]"));
            var companyRow = parentLi.FindElement(By.CssSelector(".CompanyNames"));
            return companyRow?.Text.Trim();
        }

        private IWebElement GetUpdateButtonForUser(string userName)
        {
            var userRow = GetUserRowByName(userName);
            var parentLi = userRow.FindElement(By.XPath("./ancestor::li[1]"));
            return parentLi.FindElement(By.CssSelector(".updateButton"));
        }

        private IWebElement GetDeleteButtonForUser(string userName)
        {
            var userRow = GetUserRowByName(userName);
            var parentLi = userRow.FindElement(By.XPath("./ancestor::li[1]"));
            return parentLi.FindElement(By.CssSelector(".deleteButton"));
        }

        private IWebElement EditUserElement => _wait.Until(ExpectedConditions.ElementExists(By.XPath("//h2[text()='Edit User']")));
        private IWebElement CompanyUpdateSelection => _driver.FindElement(By.Id("editedCompanyId"));
        private SelectElement CompanyUpdateSelectionElemenet => new SelectElement(CompanyUpdateSelection);
        private IWebElement UpdateUserButton => _wait.Until(ExpectedConditions.ElementExists(By.XPath("//button[text()='Update User']")));

        // Methods
        public void EnterUserName(string username) => UserNameField.SendKeys(username);

        public string GetEnteredUserName() => UserNameField.GetAttribute("value");

        public void SelectCompanyByName(string companyName)
        {
            _wait.Until(drv => CompanySelection.Displayed);
            CompanySelectionElement.SelectByText(companyName);
        }

        public string GetSelectedCompany() => CompanySelectionElement.SelectedOption.Text;

        public void ClickAddButton() => _wait.Until(ExpectedConditions.ElementToBeClickable(Addbutton)).Click();

        public void ClickUpdateButtonForUser(string userName)
        {
            var updateButton = GetUpdateButtonForUser(userName);
            _wait.Until(ExpectedConditions.ElementToBeClickable(updateButton)).Click();
        }

        public IWebElement UserRowByName(string userName) => GetUserRowByName(userName);

        public string? CompanyByUserRow(IWebElement userRow) => GetCompanyByUserRow(userRow);

        public bool IsEditUserElementDisplayed() => EditUserElement.Displayed;

        public void ClearUserNameUpdateField()
        {
            UserNameUpdateField.SendKeys(Keys.Control + "a");
            UserNameUpdateField.SendKeys(Keys.Delete);
        }

        public void EnterUserNameUpdate(string username) => UserNameUpdateField.SendKeys(username);

        public string GetEnteredUserNameUpdate() => UserNameUpdateField.GetAttribute("value");

        public void SelectUpdateCompanyByName(string companyName)
        {
            _wait.Until(drv => CompanyUpdateSelection.Displayed);
            CompanyUpdateSelectionElemenet.SelectByText(companyName);
        }

        public string GetSelectedUpdateCompany() => CompanyUpdateSelectionElemenet.SelectedOption.Text;

        public void ClickUpdateUserButton() => UpdateUserButton.Click();

        public void ClickDeleteButtonForUser(string userName)
        {
            var deleteButton = GetDeleteButtonForUser(userName);
            _wait.Until(ExpectedConditions.ElementToBeClickable(deleteButton)).Click();
        }

        public bool IsUserVisibleInTable(string userName)
        {
            bool isUserPresent = true;
            try
            {
                _wait.Until(driver =>
                {
                    var users = driver.FindElements(By.XPath($"//td[text()='{userName}']"));
                    isUserPresent = users.Any() && users.First().Displayed;
                    return !isUserPresent;
                });
            }
            catch (WebDriverTimeoutException)
            {
                isUserPresent = true;
            }
            return isUserPresent;
        }
    }
}