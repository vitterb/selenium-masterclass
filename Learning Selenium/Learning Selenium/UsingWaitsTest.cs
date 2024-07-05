using Learning_Selenium.Pages;

namespace Learning_Selenium
{
    internal class UsingWaitsTest : BaseTest
    {
        private OrderPage orderPage;

        [SetUp]
        public new void Setup()
        {
            orderPage = new OrderPage(GetDriver());
            GetDriver().Navigate().GoToUrl("http://localhost:4200/order-delay");
            GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        [Test]
        [Category("Tests with Assertions")]
        [Category("Test Creator = Bert Van Itterbeeck")]
        public void ImplicitlyWaitingForTheOrderToProcessTest()
        {
            orderPage.EnterName("Josh Smith");
            orderPage.SelectWorkshop(1);
            orderPage.ClickAddButton();
            orderPage.ScrollToTheOrderButton();
            var orderStatusPage = orderPage.ClickOrderButton();
            Assert.That(orderStatusPage.GetOrderSuccessMessageText(), Is.EqualTo("Your order has been successfully created!"));
        }

        [Test]
        [Category("Tests with Assertions")]
        [Category("Test Creator = Bert Van Itterbeeck")]
        public void ExplicitlyWaitingForTheOrderToProcessTest()
        {
            orderPage.EnterName("Josh Smith");
            orderPage.SelectWorkshop(1);
            orderPage.ClickAddButton();
            orderPage.ScrollToTheOrderButton();
            var orderStatusPage = orderPage.ClickOrderButton();
            GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            orderStatusPage.WaitForTheOrderSuccessPageToBecomeVisable(TimeSpan.FromSeconds(15));
            Assert.That(orderStatusPage.GetOrderSuccessMessageText(), Is.EqualTo("Your order has been successfully created!"));
        }
    }
}