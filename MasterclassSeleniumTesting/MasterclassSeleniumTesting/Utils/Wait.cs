using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;

namespace MasterclassSeleniumTesting.Utils
{
    internal class Wait
    {
        private readonly IWebDriver driver;

        public Wait(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void WaitForElementToBeVisible(Func<IWebElement> el, TimeSpan time)
        {
            var wait = new WebDriverWait(driver, time);
            wait.Until((_) => el.Invoke().Displayed);
        }
        public void WaitForATimePeriod(TimeSpan time)
        {
            var stopwatch = Stopwatch.StartNew();
            new WebDriverWait(new SystemClock(), driver, time, TimeSpan.FromMilliseconds(100))
                .Until(d => stopwatch.Elapsed >= time);
        }

        public IWebElement WaitForTheElementToBecomeVisible(By by, TimeSpan time)
        {
            var wait = new WebDriverWait(driver, time);
            return wait.Until((_) =>
            {
                var element = driver.FindElement(by);
                if (element.Displayed)
                {
                    return element;
                }
                else
                {
                    throw new NoSuchElementException($"The element {(by as By).ToString()} was not visible");
                }
            });
        }
    }
}