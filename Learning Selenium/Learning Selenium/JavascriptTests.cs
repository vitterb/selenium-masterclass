using Learning_Selenium.Pages;

namespace Learning_Selenium
{
    internal class JavascriptTests : BaseTest
    {
        private OrderPage orderPage;

        [SetUp]
        public new void Setup()
        {
            orderPage = new OrderPage(GetDriver());
        }

        [Test]
        [Category("Tests with Assertions")]
        [Category("Test Creator = Bert Van Itterbeeck")]
        public void ScrollingToElementTest()
        {
            orderPage.EnterName("Josh Smith");
            orderPage.SelectWorkshop(1);
            orderPage.ClickAddButton();
            Thread.Sleep(2000);
            orderPage.ScrollToTheOrderButton();
            orderPage.ClickOrderButton();
            Thread.Sleep(2000);
            Assert.That(GetDriver().Url, Contains.Substring("succes"));
        }
    }
}