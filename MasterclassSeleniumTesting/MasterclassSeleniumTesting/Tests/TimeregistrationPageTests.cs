using MasterclassSeleniumTesting.Pages;

namespace MasterclassSeleniumTesting.Tests
{
    internal class TimeregistrationPageTests : BaseTest
    {
        private TimeRegistrationPage timeRegistrationPage;

        [SetUp]
        public new void Setup()
        {
            timeRegistrationPage = new TimeRegistrationPage(GetDriver());
            GetDriver().Navigate().GoToUrl("http://localhost:5173/timeregistrations");
        }

        [Test]
        [Category("TimeRegistrationPage")]
        [Category("Adding and deleting timeregistrations")]
        [TestCase("SeleniumTestSubject", "Adding Timeregistration Test")]

        public void AddingATimeRegistration(string userName, string TestDescription)
        {
            timeRegistrationPage.SetDescription(TestDescription);
            timeRegistrationPage.SetStart();
            timeRegistrationPage.SetStop();
            timeRegistrationPage.SetUserToAddtimeregistration(userName);
            timeRegistrationPage.ClickAddButton();
            timeRegistrationPage.SetUserDataToDisplay(userName);
            timeRegistrationPage.WaitForATimePeriod(2);
            Assert.That(timeRegistrationPage.CheckRegistrationsExist(), Is.True);
            Assert.That(timeRegistrationPage.IsTestRegistrationPresent(TestDescription), Is.True);
        }
        [Test]
        [Category("TimeRegistrationPage")]
        [Category("Adding and deleting timeregistrations")]
        [TestCase("SeleniumTestSubject", "Adding Timeregistration Test")]
        public void DeletingATimeRegistration(string userName, string registrationToDelete)
        {
            timeRegistrationPage.WaitForATimePeriod(2);
            timeRegistrationPage.SetUserDataToDisplay(userName);
            timeRegistrationPage.WaitForATimePeriod(2);
            timeRegistrationPage.Deletebutton(registrationToDelete).Click();
            timeRegistrationPage.WaitForATimePeriod(5);
            Assert.That(timeRegistrationPage.IsTestRegistrationPresent(registrationToDelete), Is.False);
        }
        [Test]
        [Category("TimeRegistrationPage")]
        [Category("Updating timeregistrations")]
        [TestCase("SeleniumTestSubject", "Adding Timeregistration Test", "Updating Timeregistration Test")]
        public void UpdatingATimeRegistration(string userName, string registrationToUpdate, string updatedRegistration)
        {
            timeRegistrationPage.SetUserDataToDisplay(userName);
            timeRegistrationPage.CheckIfTimeregistrationIsPresentInUserDataIfNotCreateRegistration(userName, registrationToUpdate);
            timeRegistrationPage.WaitForATimePeriod(2);
            timeRegistrationPage.UpdateButton(registrationToUpdate).Click();
            timeRegistrationPage.WaitForATimePeriod(2);
            timeRegistrationPage.SetUpdateDescription(updatedRegistration);
            timeRegistrationPage.WaitForATimePeriod(2);
            timeRegistrationPage.UpdateRegistrationButton().Click();
            timeRegistrationPage.WaitForATimePeriod(2);
            Assert.That(timeRegistrationPage.IsTestRegistrationPresent(updatedRegistration), Is.True);
            timeRegistrationPage.Deletebutton(updatedRegistration).Click();
        }
        [Test]
        [Category("TimeRegistrationPage")]
        [Category("updating timeregistrations")]
        [TestCase("SeleniumTestSubject", "Adding Timeregistration Test", "Updating Timeregistration Test")]
        public void CancelingUpdateRegistration(string userName, string registrationToUpdate, string updatedRegistration)
        {
            timeRegistrationPage.SetUserDataToDisplay(userName);
            timeRegistrationPage.CheckIfTimeregistrationIsPresentInUserDataIfNotCreateRegistration(userName, registrationToUpdate);
            timeRegistrationPage.WaitForATimePeriod(2);
            timeRegistrationPage.UpdateButton(registrationToUpdate).Click();
            timeRegistrationPage.WaitForATimePeriod(2);
            timeRegistrationPage.SetUpdateDescription(updatedRegistration);
            timeRegistrationPage.WaitForATimePeriod(2);
            timeRegistrationPage.UpdateCancellationButton().Click();
            timeRegistrationPage.WaitForATimePeriod(2);
            Assert.That(timeRegistrationPage.IsTestRegistrationPresent(updatedRegistration), Is.False);
            timeRegistrationPage.Deletebutton(registrationToUpdate).Click();
        }
        [Test]
        [Category("TimeRegistrationPage")]
        [Category("TimeRegistration-links")]
        public void ClickHomeLinkTest()
        {
            timeRegistrationPage.ClickHomeLinkButton();
            Assert.That(GetDriver().Url, Is.EqualTo("http://localhost:5173/"));
        }
        [Test]
        [Category("TimeRegistrationPage")]
        [Category("TimeRegistration-links")]
        public void ClickCompanyLinkTest()
        {
            timeRegistrationPage.ClickCompaniesLinkButton();
            Assert.That(GetDriver().Url, Contains.Substring("Companies"));
        }
        [Test]
        [Category("TimeRegistrationPage")]
        [Category("TimeRegistration-links")]
        public void ClickUsersLinkTest()
        {
            timeRegistrationPage.ClickUsersLinkButton();
            Assert.That(GetDriver().Url, Contains.Substring("users"));
        }
    }
}
