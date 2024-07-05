using MasterclassSeleniumTesting.Pages;

namespace MasterclassSeleniumTesting.Tests
{
    internal class CompaniesPageTests : BaseTest
    {
        private CompaniesPage companiesPage;

        [SetUp]
        public new void Setup()
        {
            companiesPage = new CompaniesPage(GetDriver());
            GetDriver().Navigate().GoToUrl("http://localhost:5173/companies");
        }

        [Test]
        [Category("CompanyPage")]
        [Category("Companies-Links")]
        public void ClickUsersLinkTest()
        {
            companiesPage.ClickUsersButton();
            Assert.That(GetDriver().Url, Contains.Substring("users"));
        }

        [Test]
        [Category("CompanyPage")]
        [Category("Companies-Links")]
        public void ClickHomeLinkTest()
        {
            companiesPage.ClickHomeButton();
            Assert.That(GetDriver().Url, Is.EqualTo("http://localhost:5173/"));
        }

        [Test]
        [Category("CompanyPage")]
        [Category("Companies-Links")]
        public void ClickTimeRegistrationsLinkTest()
        {
            companiesPage.ClickTimeRegistrationsButton();
            Assert.That(GetDriver().Url, Contains.Substring("timeregistrations"));
        }

        [Test]
        [Category("CompanyPage")]
        [Category("Companies-NameChecking")]
        public void CheckFirstCompanyName()
        {
            companiesPage.WaitForCampanyNamesToLoad();
            Assert.That(companiesPage.ReturnCompanyWithIndex(0), Is.EqualTo("Disney"));
        }

        [Test]
        [Category("CompanyPage")]
        [Category("Companies-NameChecking")]
        [TestCase(0, "Disney")]
        [TestCase(1, "Looney Toons")]
        public void CheckSecondCompanyName(int companyIndex, string companyName)
        {
            companiesPage.WaitForEmployeeNamesToLoad();
            Assert.That(companiesPage.ReturnCompanyWithIndex(companyIndex), Is.EqualTo(companyName));
        }

        [Test]
        [Category("CompanyPage")]
        [Category("Companies-CountingEmployees")]
        public void CheckFirstCompanyEmployeeCount()
        {
            companiesPage.WaitForCampanyNamesToLoad();
            Assert.That(companiesPage.ReturnEmployeeCountWithIndex(0), Is.EqualTo(6));
        }

        [Test]
        [Category("CompanyPage")]
        [Category("Companies-EmployeesNamesAreDisplayedCorrectly")]
        [TestCase(0, 0, "Mickey Mouse")]
        [TestCase(0, 2, "Donald Duck")]
        [TestCase(1, 0, "Bugs Bunny")]
        public void CheckFirstEmployeeOfFirstCompany(int companyIndex, int employeeIndex, string employeeName)
        {
            companiesPage.WaitForEmployeeNamesToLoad();
            Assert.That(companiesPage.ReturnEmployeeNameWithIndex(companyIndex, employeeIndex), Is.EqualTo(employeeName));
        }

        [Test]
        [Category("CompanyPage")]
        [Category("Adding and deleting Company")]
        public void AddCompany()
        {
            companiesPage.EnterCompanyName("TestCompany");
            companiesPage.ClickAddCompanyButton();
            companiesPage.WaitForTestCompanyToLoad();
            Assert.That(companiesPage.ReturnCompanyWithIndex(2), Is.EqualTo("TestCompany"));
        }

        [Test]
        [Category("CompanyPage")]
        [Category("Adding and deleting Company")]
        public void DeleteTestCompany()
        {
            companiesPage.WaitForTestCompanyToLoad();
            companiesPage.ClickOnDeleteButton();
        }
    }
}