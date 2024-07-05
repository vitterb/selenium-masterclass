using Learning_Selenium.Utils;
using OpenQA.Selenium;

namespace Learning_Selenium.Pages
{
    internal class OrderStatusPage : BasePage
    {
        public OrderStatusPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement OrderSuccessMessage => driver.FindElement(By.Id("order-success"));

        public void WaitForTheOrderSuccessPageToBecomeVisable(TimeSpan timespan)
        {
            new Wait(driver).WaitForElementToBeVisible(() => OrderSuccessMessage, timespan);
        }

        public string GetOrderSuccessMessageText()
        {
            return OrderSuccessMessage.Text;
        }
    }
}