    using MasterclassSeleniumTesting.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Drawing.Text;
using System.Security.Cryptography.X509Certificates;

namespace MasterclassSeleniumTesting.Pages
{
    internal class UsersPage : BasePage
    {
        public UsersPage(IWebDriver driver) : base(driver) { }

        private IList<IWebElement> UserElements => driver.FindElements(By.ClassName("UserNames"));
        private IWebElement AddUserButton => driver.FindElement(By.XPath("//*[@id='root']/div/div[2]/div/form/table/tbody/tr[5]/td/button"));
        private IWebElement UserNameInput => driver.FindElement(By.Id("userName"));
        private IWebElement UpdateUserNameInput => driver.FindElement(By.XPath("//*[@id='editedUserName']"));
        private IWebElement CompanySelection => driver.FindElement(By.XPath("//*[@id='companyId']"));
        private SelectElement CompanySelectionElement(IWebElement element) => new SelectElement(element);
        private IWebElement UpdateUserButton => driver.FindElement(By.XPath("//button[text()='Update User' and contains(@class, 'is-warning')]"));
        private IWebElement HomeButton => driver.FindElement(By.LinkText("Home"));
        private IWebElement CompaniesButton => driver.FindElement(By.LinkText("Companies"));
        private IWebElement TimeRegistrationsButton => driver.FindElement(By.LinkText("Time Registrations"));
        private bool userExistscheck;

        public void ClickHomeButton()
        {
            HomeButton.Click();
        }

        public void ClickCompaniesButton()
        {
            CompaniesButton.Click();
        }

        public void ClickTimeRegistrationsButton()
        {
            TimeRegistrationsButton.Click();
        }

        public void SelectCompanyOutOfDropDownMenubyText(string text)
        {
            CompanySelectionElement(CompanySelection).SelectByText(text);
        }

        public void ClickAddUserButton()
        {
            AddUserButton.Click();
        }

        public void EnterUpdatedUserName(string userName)
        {
            UpdateUserNameInput.Clear();
            UpdateUserNameInput.SendKeys(userName);
        }

        public void EnterUserName(string userName)
        {
            UserNameInput.SendKeys(userName);
        }

        public void ClickUpdateUserButton()
        {
            UpdateUserButton.Click();
        }

        public void WaitForUsersToLoad()
        {
            var wait = new Wait(driver);
            wait.WaitForTheElementToBecomeVisible(By.ClassName("UserNames"), TimeSpan.FromSeconds(15));
        }

        public void WaitForCompaniesToLoad()
        {
            var wait = new Wait(driver);
            wait.WaitForTheElementToBecomeVisible(By.ClassName("CompanyNames"), TimeSpan.FromSeconds(15));
        }

        public bool IsUserPresent(string userName)
        {
            foreach (var user in UserElements)
            {
                if (user.Text.Equals(userName, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public void ClickDeleteButtonNextToUser(string userName)
        {
            int index = -1;
            for (int i = 0; i < UserElements.Count; i++)
            {
                if (UserElements[i].Text.Equals(userName, StringComparison.OrdinalIgnoreCase))
                {
                    index = i;
                    break;
                }
            }
            var deleteButtons = driver.FindElements(By.XPath(".//button[text()='Delete']"));

            if (deleteButtons.Count > index)
            {
                deleteButtons[index].Click();
            }
        }

        public void ClickUpdateButtonNextToUser(string userName)
        {
            int index = -1;
            for (int i = 0; i < UserElements.Count; i++)
            {
                if (UserElements[i].Text.Equals(userName, StringComparison.OrdinalIgnoreCase))
                {
                    index = i;
                    break;
                }
            }
            var UpdateButtons = driver.FindElements(By.XPath(".//button[text()='Update']"));

            if (UpdateButtons.Count > index)
            {
                UpdateButtons[index].Click();
            }
        }

        public void WaitForATimePeriod(int seconds)
        {
            var wait = new Wait(driver);
            wait.WaitForATimePeriod(TimeSpan.FromSeconds(seconds));
        }

        public bool CheckNamesAndCompanies(string user, string company)
        {
            IWebElement userElement = driver.FindElement(By.XPath($"//td[contains(@class, 'UserNames') and text()='{user}']"));
            IWebElement companyElement = userElement.FindElement(By.XPath("./ancestor::tr/following-sibling::tr//td[contains(@class, 'CompanyNames')]"));
            return companyElement.Text.Equals(company);
        }

        public void IsUserIsNotPresentThenCreateUser(string userName, string companyName)
        {
            userExistscheck = false;
            WaitForATimePeriod(2);
            foreach (var user in UserElements)
            {
                if (user.Text.Equals(userName, StringComparison.OrdinalIgnoreCase))
                {
                    userExistscheck = true;
                }
            }
            WaitForATimePeriod(2);
            if (userExistscheck == false)
            {
                EnterUserName(userName);
                SelectCompanyOutOfDropDownMenubyText(companyName);
                ClickAddUserButton();
            }
        }

        public IWebElement IsEditFormPresent()
        {
            var wait = new Wait(driver);
            IWebElement editForm = driver.FindElement(By.Id("editedUserName"));
            return wait.WaitForTheElementToBecomeVisible(By.Id("editedUserName"), TimeSpan.FromSeconds(15));
        }
    }
}