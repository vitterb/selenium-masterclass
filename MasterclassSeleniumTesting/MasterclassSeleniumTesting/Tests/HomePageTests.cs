using MasterclassSeleniumTesting.Pages;

namespace MasterclassSeleniumTesting.Tests
{
    internal class HomePageTests : BaseTest
    {
        private Homepage homepage;

        [SetUp]
        public new void Setup()
        {
            homepage = new Homepage(GetDriver());
        }

        [Test]
        [Category("Home-Links")]
        public void ClickUsersLinkTest()
        {
            homepage.ClickUsersLink();
            Assert.That(GetDriver().Url, Contains.Substring("users"));
        }

        [Test]
        [Category("Home-Links")]
        public void ClickCompaniesLinkTest()
        {
            homepage.ClickCompaniesLink();
            Assert.That(GetDriver().Url, Contains.Substring("companies"));
        }

        [Test]
        [Category("Home-Links")]
        public void ClickTimeRegistrationsLinkTest()
        {
            homepage.ClickTimeRegistrationsLink();
            Assert.That(GetDriver().Url, Contains.Substring("timeregistrations"));
        }
    }
}