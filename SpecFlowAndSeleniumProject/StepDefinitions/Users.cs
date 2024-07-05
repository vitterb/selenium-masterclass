using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowAndSeleniumProject.Pages;

namespace SpecFlowAndSeleniumProject.StepDefinitions
{
    [Binding]
    public class Users
    {
        private UserPage _userPage;

        public Users(IWebDriver driver)
        {
            _userPage = new UserPage(driver);
        }

        [Given(@"I go to the application UsersPage")]
        public void GivenIGoToTheApplicationUsersPage()
        {
            _userPage.GoToUserPage();
            Assert.IsTrue(_userPage.GetCurrentUrl().EndsWith("/users"), "Not on the UsersPage");
        }

        [When(@"I add a new user name in the input field")]
        public void WhenIAddANewUserNameInTheInputField()
        {
            _userPage.EnterUserName("TestUser");
            Assert.AreEqual("TestUser", _userPage.GetEnteredUserName(), "Username was not entered correctly");
        }

        [When(@"I select the company from the company dropdown menu")]
        public void WhenISelectTheCompanyFromTheCompanyDropdownMenu()
        {
            _userPage.SelectCompanyByName("Looney Toons");
            Assert.AreEqual("Looney Toons", _userPage.GetSelectedCompany(), "Company was not selected correctly");
        }

        [When(@"I click on the add user button")]
        public void WhenIClickOnTheAddUserButton()
        {
            _userPage.ClickAddButton();
        }

        [Then(@"I should see the user in the user table with the correct company")]
        public void ThenIShouldSeeTheUserInTheUserTableWithTheCorrectCompany()
        {
            Assert.IsNotNull(_userPage.UserRowByName("TestUser"), "The username TestUser is not found in the user table");
            Assert.IsNotNull(_userPage.CompanyByUserRow(_userPage.UserRowByName("TestUser")), "No company found for TestUser");
            Assert.AreEqual("Looney Toons", _userPage.CompanyByUserRow(_userPage.UserRowByName("TestUser")), "TestUser is not associated with Looney Toons");
        }

        [When(@"I click on the edit button of the user")]
        public void WhenIClickOnTheEditButtonOfTheUser()
        {
            Assert.IsNotNull(_userPage.UserRowByName("TestUser"), "The username TestUser is not found in the user table");
            _userPage.ClickUpdateButtonForUser("TestUser");
        }

        [Then(@"I get the update menu")]
        public void ThenIGetTheUpdateMenu()
        {
            Assert.IsTrue(_userPage.IsEditUserElementDisplayed(), "Edit User title not found!");
        }

        [When(@"I change the user name in the updateField")]
        public void WhenIChangeTheUserNameInTheUpdateField()
        {
            _userPage.ClearUserNameUpdateField();
            _userPage.EnterUserNameUpdate("UpdatedUserName");
            Assert.AreEqual("UpdatedUserName", _userPage.GetEnteredUserNameUpdate(), "Username was not changed correctly");
        }

        [When(@"I change the company in the updatecompany dropdown menu")]
        public void WhenIChangeTheCompanyInTheUpdatecompanyDropdownMenu()
        {
            _userPage.SelectUpdateCompanyByName("Disney");
            Assert.AreEqual("Disney", _userPage.GetSelectedUpdateCompany(), "Company was not changed correctly");
        }

        [When(@"I click the update user button")]
        public void WhenIClickTheUpdateUserButton()
        {
            _userPage.ClickUpdateUserButton();
        }

        [Then(@"I should see the updated user in the user table with the correct company")]
        public void ThenIShouldSeeTheUpdatedUserInTheUserTableWithTheCorrectCompany()
        {
            Assert.IsNotNull(_userPage.UserRowByName("UpdatedUserName"), "The username UpdatedUserName is not found in the user table");
            Assert.IsNotNull(_userPage.CompanyByUserRow(_userPage.UserRowByName("UpdatedUserName")), "No company found for TestUser");
            Assert.AreEqual("Disney", _userPage.CompanyByUserRow(_userPage.UserRowByName("UpdatedUserName")), "UpdatedUserName is not associated with Disney");
        }

        [When(@"I click on the delete button of the user")]
        public void WhenIClickOnTheDeleteButtonOfTheUser()
        {
            Assert.IsNotNull(_userPage.UserRowByName("UpdatedUserName"), "The username TestUser is not found in the user table");
            _userPage.ClickDeleteButtonForUser("UpdatedUserName");
        }

        [Then(@"I should not see the user in the user table")]
        public void ThenIShouldNotSeeTheUserInTheUserTable()
        {
            Assert.IsFalse(_userPage.IsUserVisibleInTable("UpdatedUserName"), "The username UpdatedUserName is still found in the user table");
        }
        [When(@"I click on the HomePage link")]
        public void WhenIClickOnTheHomePageLink()
        {
            _userPage.ClickHomeLink();
        }

        [Then(@"I should have navigated to the HomePage")]
        public void ThenIShouldHaveNavigatedToTheHomePage()
        {
            Assert.That(_userPage.GetCurrentUrl(), Is.EqualTo("http://localhost:5173/"));
        }

    }
}