using OpenQA.Selenium;

namespace Learning_Selenium.Pages
{
    internal class BasePage
    {
        protected IWebDriver driver;

        protected BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        protected void ScrollToElement(IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(500);
        }
    }
}