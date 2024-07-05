using MasterclassSeleniumTesting.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MasterclassSeleniumTesting.Pages
{
    internal class TimeRegistrationPage : BasePage
    {
        public TimeRegistrationPage(IWebDriver driver) : base(driver) { }
        private IWebElement timeregistrationDescriptionInput => driver.FindElement(By.XPath("//*[@id='root']/div/div/div[1]/form/table/tbody/tr[3]/td/input"));
        private IWebElement timeregistrationStartInput => driver.FindElement(By.XPath("//*[@id='root']/div/div/div[1]/form/table/tbody/tr[5]/td/input"));
        private IWebElement timeregistrationStopInput => driver.FindElement(By.XPath("//*[@id='root']/div/div/div[1]/form/table/tbody/tr[7]/td/input"));
        private IWebElement timeregistrationUserInput => driver.FindElement(By.XPath("//*[@id='root']/div/div/div[1]/form/table/tbody/tr[9]/td/select"));
        private IWebElement timeregistrationAddButton => driver.FindElement(By.XPath("//*[@id='root']/div/div/div[1]/form/table/tbody/tr[10]/td/button"));
        private IWebElement UserDataToDisplay => driver.FindElement(By.XPath("//select[@name='selectedUser']"));
        private List<IWebElement> Registrations => driver.FindElements(By.XPath("//*[@id='root']/div/div/div[1]/ul/li")).ToList();
        private IWebElement UpdateInputDescription => driver.FindElement(By.Id("editedRegistrationName"));
        private IWebElement HomeButton => driver.FindElement(By.LinkText("Home"));
        private IWebElement CompaniesButton => driver.FindElement(By.LinkText("Companies"));
        private IWebElement UsersButton => driver.FindElement(By.LinkText("Users"));

        public IWebElement Deletebutton(string registrationToDelete)
        {
            string xpath= "//*[@id='root']/div/div/div[1]/ul/li/button[1]";
            return driver.FindElement(By.XPath(xpath));
        }
        public IWebElement UpdateButton(string registrationToUpdate)
        {
            string xpath = $"//*[@id='root']/div/div/div[1]/ul/li[contains(.,'{registrationToUpdate}')]/button[2]";
            return driver.FindElement(By.XPath(xpath));
        }
        public IWebElement UpdateRegistrationButton()
        {
            string xpath = "//*[@id='root']/div/div/div[1]/ul/li/div/form/table/tbody/tr[4]/td[1]/button";
            return driver.FindElement(By.XPath(xpath));
        }
        public IWebElement UpdateCancellationButton()
        {
            string xpath = "//*[@id=\"root\"]/div/div/div[1]/ul/li/div/form/table/tbody/tr[4]/td[2]/button";
            return driver.FindElement(By.XPath(xpath));
        }
        public void ClickHomeLinkButton()
        {
            HomeButton.Click();
        }
        public void ClickCompaniesLinkButton()
        {
            CompaniesButton.Click();
        }
        public void ClickUsersLinkButton()
        {
            UsersButton.Click();
        }
        public void SetUpdateDescription(string description)
        {
            UpdateInputDescription.Clear();
            UpdateInputDescription.SendKeys(description);
        }
        public bool CheckRegistrationsExist()
        {
            if(!Registrations.Any()) 
            { 
                return false; 
            }
            else 
            { 
                return true; 
            }
        }
        public bool IsTestRegistrationPresent(string registrationText)
        {  
            return Registrations.Any(reg => reg.Text.Contains(registrationText));   
        }
        public void SetDescription(string description)
        {
           
            timeregistrationDescriptionInput.SendKeys(description);
        }
        public void SetStart()
        {
            DateTime now = DateTime.Now;
            string StartDate = now.ToString("dd-MM-yyyy");
            string StartTime = now.ToString("HH:mm");
            timeregistrationStartInput.Clear();
            timeregistrationStartInput.SendKeys(StartDate + Keys.ArrowRight + StartTime);
        }
        public void SetStop()
        {
            DateTime now = DateTime.Now;
            DateTime futureTime = now.AddMinutes(30);
            string stopDate = futureTime.ToString("dd-MM-yyyy");
            string stopTime = futureTime.ToString("HH:mm");
            timeregistrationStopInput.Clear();
            timeregistrationStopInput.SendKeys(stopDate + Keys.ArrowRight + stopTime);
        }
        public void SetUserToAddtimeregistration(string user)
        {
            SelectElement selectElement = new SelectElement(timeregistrationUserInput);
            selectElement.SelectByText(user);
        }
        public void ClickAddButton()
        {
            timeregistrationAddButton.Click();
        }
        public void WaitForATimePeriod(int seconds)
        {
            var wait = new Wait(driver);
            wait.WaitForATimePeriod(TimeSpan.FromSeconds(seconds));
        }
        public void SetUserDataToDisplay(string user)
        {
            SelectElement selectElement = new SelectElement(UserDataToDisplay);
            selectElement.SelectByText(user);
        }
        public void CheckIfTimeregistrationIsPresentInUserDataIfNotCreateRegistration(string user, string registrationDescription)
        {
            if (!IsTestRegistrationPresent(registrationDescription))
            {
                SetDescription(registrationDescription);
                SetStart();
                SetStop();
                SetUserToAddtimeregistration(user);
                ClickAddButton();
            }
        }
    }
}
