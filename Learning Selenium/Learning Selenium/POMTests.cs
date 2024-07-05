using Learning_Selenium.Pages;
using OpenQA.Selenium;

namespace Learning_Selenium
{
    internal class POMTests : BaseTest
    {
        private OrderPage orderPage;

        [SetUp]
        public new void Setup()
        {
            orderPage = new OrderPage(GetDriver());
        }

        [Test]
        [Category("Tests without assertions")]
        [Category("Test Creator = Bert Van Itterbeeck")]
        public void SimpleTest()
        {
            orderPage.EnterName("Josh Smith");
            orderPage.ClickAddButton();
        }

        [Test]
        [Category("Tests without assertions")]
        [Category("Test Creator = Bert Van Itterbeeck")]
        public void UsingRelativeLocatorTest()
        {
            orderPage.EnterNotes("something important");
            orderPage.SelectWorkshop(0);
        }

        [Test]
        [Category("Tests with Assertions")]
        [Category("Test Creator = Bert Van Itterbeeck")]
        public void SimpleTestWithAssertion()
        {
            orderPage.EnterName("Josh Smith");
            orderPage.ClickAddButton();
            Assert.That(orderPage.GetTotalPrice(), Is.EqualTo("$100.00"), "TotalPrice is not valid");
        }

        [Test]
        [Category("Tests with Assertions")]
        [Category("Test Creator = Bert Van Itterbeeck")]
        public void NavigationTest()
        {
            Assert.That(orderPage.CheckUrl, Contains.Substring("http://localhost:4200"));
        }

        [Test]
        [Category("Tests with Assertions")]
        [Category("Test Creator = Bert Van Itterbeeck")]
        public void UsingClickTest()
        {
            orderPage.EnterName("Josh Smith");
            orderPage.ClickAddButton();
            Assert.That(orderPage.EntryCount, Is.EqualTo(1));
        }

        [Test]
        [Category("Tests with Assertions")]
        [Category("Test Creator = Bert Van Itterbeeck")]
        public void UsingDoubleClickTest()
        {
            orderPage.EnterName("Josh Smith");
            orderPage.DoubleClickAddButton();
            Assert.That(orderPage.IsValidationErrorDisplayed, Is.True);
        }

        [Test]
        [Category("Tests with Assertions")]
        [Category("Test Creator = Bert Van Itterbeeck")]
        public void CoordinatesClickTest()
        {
            orderPage.CoordinatesClick();
            Assert.That(orderPage.IsValidationErrorDisplayed, Is.True);
        }

        [Test]
        [Category("Tests with Assertions")]
        [Category("Test Creator = Bert Van Itterbeeck")]
        public void UsingSendKeysAndClearTest()
        {
            Assert.That(orderPage.UsingSendKeysAndClearTest(), Is.EqualTo("5% discount"));
        }

        [Test]
        [Category("Tests with Assertions")]
        [Category("Test Creator = Bert Van Itterbeeck")]
        public void fileUploadTest()
        {
            Assert.That(orderPage.PhotoUpload(), Contains.Substring("Caizar.jpg"));
        }

        [Test]
        [Category("Tests with Assertions")]
        [Category("Test Creator = Bert Van Itterbeeck")]
        public void PressingKeysTest()
        {
            orderPage.EnterName("Josh Smith");
            orderPage.pressingKeys();
            Assert.That(orderPage.IsValidationErrorDisplayed, Is.True);
        }

        [Test]
        [Category("Tests with Assertions")]
        [Category("Test Creator = Bert Van Itterbeeck")]
        public void SelectingDropdownOptionTestValue()
        {
            orderPage.SelectingDropdownOptionbyText();
            Assert.That(orderPage.LunchSelectionAttribute, Is.EqualTo("true"));
        }

        [Test]
        [Category("Tests with Assertions")]
        [Category("Test Creator = Bert Van Itterbeeck")]
        public void SelectingDropdownOptionTestText()
        {
            orderPage.SelectingDropdownOptionbyValue();
            Assert.That(orderPage.LunchSelectionText, Is.EqualTo("No"));
        }

        [Test]
        [Category("Tests with Assertions")]
        [Category("Test Creator = Bert Van Itterbeeck")]
        public void SelectingCheckboxItems()
        {
            orderPage.SelectingCheckboxItem();
            Assert.That(orderPage.SelectedWorkshop1, Is.True);
        }

        [Test]
        [Category("Tests with Assertions")]
        [Category("Test Creator = Bert Van Itterbeeck")]
        public void HandelingAlertsAndConformationTests()
        {
            GetDriver().Navigate().GoToUrl("http://localhost:4200/show-alert");
            orderPage.EnterName("Josh Smith");
            orderPage.ClickAddButton();

            var alertWindow = GetDriver().SwitchTo().Alert();
            alertWindow.Accept();

            orderPage.ScrollToTicketRemoveButton(0);
            orderPage.ClickOnTheTicketRemoveButton(0);
            var conformationWindow = GetDriver().SwitchTo().Alert();
            conformationWindow.Dismiss();
            Assert.That(orderPage.GetOrderTicketsCount(), Is.EqualTo(1));
        }

        [Test]
        [Category("Tests with Assertions")]
        [Category("Test Creator = Bert Van Itterbeeck")]
        public void ManagingWindowsTest()
        {
            var window1 = GetDriver().CurrentWindowHandle;
            orderPage.EnterName("window1");
            GetDriver().SwitchTo().NewWindow(WindowType.Window);
            GetDriver().Navigate().GoToUrl("http://localhost:4200");
            var window2 = GetDriver().CurrentWindowHandle;
            orderPage.EnterName("window2");
            GetDriver().SwitchTo().Window(window1);
            Assert.That(orderPage.GetNameValue(), Is.EqualTo("window1"));
            GetDriver().SwitchTo().Window(window2);
            Assert.That(orderPage.GetNameValue(), Is.EqualTo("window2"));
        }

        [Test]
        [Category("Tests with Assertions")]
        [Category("Test Creator = Bert Van Itterbeeck")]
        public void ManagingTabsTest()
        {
            var tab1 = GetDriver().CurrentWindowHandle;
            orderPage.EnterName("window1");
            GetDriver().SwitchTo().NewWindow(WindowType.Tab);
            GetDriver().Navigate().GoToUrl("http://localhost:4200");
            var tab2 = GetDriver().CurrentWindowHandle;
            orderPage.EnterName("window2");
            GetDriver().SwitchTo().Window(tab1);
            Assert.That(orderPage.GetNameValue(), Is.EqualTo("window1"));
            GetDriver().SwitchTo().Window(tab2);
            Assert.That(orderPage.GetNameValue(), Is.EqualTo("window2"));
        }
    }
}