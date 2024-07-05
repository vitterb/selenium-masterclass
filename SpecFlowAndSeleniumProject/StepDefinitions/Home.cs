using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowAndSeleniumProject.Pages;

namespace SpecFlowAndSeleniumProject.StepDefinitions
{
    [Binding]
    public class Home
    {
        private readonly HomePage _homePage;

        public Home(IWebDriver driver)
        {
            _homePage = new HomePage(driver);
        }

        [Given(@"I go to the application HomePage")]
        public void GivenIGoToTheApplication()
        {
            _homePage.GoToHomePage();
        }

        [When(@"I click on the User page link")]
        public void WhenIClickOnTheUserPageLink()
        {
            _homePage.ClickUserLink();
        }

        [Then(@"I should have navigated to the User page")]
        public void ThenIShouldHaveNavigatedToTheUserPage()
        {
            Assert.That(_homePage.GetCurrentUrl(), Is.EqualTo("http://localhost:5173/users"));
        }

        [When(@"I click on the Company page link")]
        public void WhenIClickOnTheCompanyPageLink()
        {
            _homePage.ClickCompanyLink();
        }

        [Then(@"I should have navigated to the company page")]
        public void ThenIShouldHaveNavigatedToTheCompanyPage()
        {
            Assert.That(_homePage.GetCurrentUrl(), Is.EqualTo("http://localhost:5173/companies"));
        }

        [When(@"I click on the TimeRegistration page link")]
        public void WhenIClickOnTheTimeRegistrationPageLink()
        {
            _homePage.ClickTimeRegistrationLink();
        }

        [Then(@"I should have navigated to the timeRegistration page")]
        public void ThenIShouldHaveNavigatedToTheTimeRegistrationPage()
        {
            Assert.That(_homePage.GetCurrentUrl(), Is.EqualTo("http://localhost:5173/timeregistrations"));
        }
    }
}