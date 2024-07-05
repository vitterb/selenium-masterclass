using MasterclassSeleniumTesting.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterclassSeleniumTesting.Tests
{
    internal class UserPageTests : BaseTest
    {
        private UsersPage userPage;

        [SetUp]
        public new void Setup()
        {
            userPage = new UsersPage(GetDriver());
            GetDriver().Navigate().GoToUrl("http://localhost:5173/users");
        }
        [TearDown]
        public new void Teardown()
        {
            if (userPage.IsUserPresent("testdummy"))
            {
                userPage.ClickDeleteButtonNextToUser("testdummy");
                userPage.WaitForATimePeriod(2);
            }
            if (userPage.IsUserPresent("Test Dummy"))
            {
                userPage.ClickDeleteButtonNextToUser("Test Dummy");
                userPage.WaitForATimePeriod(2); 
            }
        } 
        [Test]
        [Category("UserPage")]
        [Category("Adding and deleting users")]
        [TestCase("TestUser","Looney Toons")]
        public void AddUserTest(string userName,string company)
        {
            userPage.EnterUserName(userName);
            userPage.SelectCompanyOutOfDropDownMenubyText(company);
            userPage.ClickAddUserButton();
            userPage.WaitForATimePeriod(2);
            Assert.That(userPage.IsUserPresent(userName), Is.True);
        }
        [Test]
        [Category("UserPage")]
        [Category("Adding and deleting users")]
        [TestCase("TestUser")]
        public void DeleteUserTest(string userName)
        {
            userPage.WaitForUsersToLoad();
            userPage.ClickDeleteButtonNextToUser(userName);
            userPage.WaitForATimePeriod(2);
            Assert.That(userPage.IsUserPresent(userName), Is.False);
            
        }
        [Test]
        [Category("UserPage")]
        [Category("User-links")]
        public void ClickHomeLinkTest()
        {
            userPage.ClickHomeButton();
            Assert.That(GetDriver().Url, Is.EqualTo("http://localhost:5173/"));
        }
        [Test]
        [Category("UserPage")]
        [Category("User-links")]
        public void ClickCompanyLinkTest()
        {
            userPage.ClickCompaniesButton();
            Assert.That(GetDriver().Url, Contains.Substring("companies"));
        }
        [Test]
        [Category("UserPage")]
        [Category("User-links")]
        public void ClickTimeRegistrationsLinkTest()
        {
            userPage.ClickTimeRegistrationsButton();
            Assert.That(GetDriver().Url, Contains.Substring("timeregistrations"));
        }
        [Test]
        [Category("UserPage")]
        [Category("User-Name-Company_Checking")]
        [TestCase("Mickey Mouse", "Disney")]
        [TestCase("Donald Duck", "Disney")]
        [TestCase("Bugs Bunny", "Looney Toons")]
        public void CheckUserNameAgainstCompany(string name,string company)
        {
            userPage.WaitForUsersToLoad();
            Assert.That(userPage.CheckNamesAndCompanies(name, company), Is.True);
        }
        [Test]
        [Category("UserPage")]
        [Category("Update-Menu")]
        [TestCase("testdummy", "Looney Toons")]
        public void UpdateMenuAppearsWhenUpdateButtonIsClicked(string userName, string company) 
        {
            userPage.IsUserIsNotPresentThenCreateUser(userName, company);
            userPage.ClickUpdateButtonNextToUser(userName);
            IWebElement editform = userPage.IsEditFormPresent();
            Assert.That(editform, Is.Not.Null);
            Assert.That(editform.Displayed, Is.True);
        }
        [Test]
        [Category("UserPage")]
        [Category("Update-Menu")]
        [TestCase("testdummy", "Looney Toons", "Test Dummy")]
        public void UpdateUserFunctions(string userName, string company, string updatedUser)
        {
            userPage.IsUserIsNotPresentThenCreateUser(userName, company);
            userPage.ClickUpdateButtonNextToUser(userName);
            userPage.WaitForATimePeriod(2);
            userPage.EnterUpdatedUserName(updatedUser);
            userPage.ClickUpdateUserButton();
            userPage.WaitForATimePeriod(2);
            Assert.That(userPage.IsUserPresent(updatedUser), Is.True);
        }
    }
}
