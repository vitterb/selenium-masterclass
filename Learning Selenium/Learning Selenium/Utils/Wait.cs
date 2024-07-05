using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Learning_Selenium.Utils
{
    public class Wait
    {
        private readonly IWebDriver driver;

        public Wait(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void WaitForElementToBeVisible(Func<IWebElement> element, TimeSpan timespan)
        {
            var wait = new WebDriverWait(driver, timespan);
            wait.Until((_) => element.Invoke().Displayed);
        }

        public IWebElement WaitForTheElementToBecomeVisible(By by, TimeSpan timeSpan)
        {
            var wait = new WebDriverWait(driver, timeSpan);
            return wait.Until((_) =>
            {
                var element = driver.FindElement(by);
                if (element.Displayed)
                {
                    return element;
                }
                return null;
            });
        }
    }
}