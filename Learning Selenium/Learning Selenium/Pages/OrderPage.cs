using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Learning_Selenium.Pages
{
    internal class OrderPage : BasePage
    {
        public OrderPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement Name => driver.FindElement(By.Id("full-name"));
        private IWebElement AddButton => driver.FindElement(By.Id("add-btn"));
        private IWebElement TotalPrice => driver.FindElement(By.CssSelector("tfoot tr th:nth-child(3)"));
        private IWebElement OrderButton => driver.FindElement(By.Id("order-btn"));

        private List<IWebElement> Workshops => driver.FindElements(RelativeBy
            .WithLocator(By.CssSelector("input[type='checkbox']"))
            .Below(Name))
            .ToList();

        private IWebElement Notes => driver.FindElement(RelativeBy
            .WithLocator(By.TagName("textarea"))
            .Below(Name));

        private IWebElement TextArea => driver.FindElement(By.Id("notes"));
        private IWebElement PhotoInput => driver.FindElement(By.Id("photo"));
        private IWebElement lunchDropDown => driver.FindElement(By.Id("include-lunch"));
        private IWebElement Workshop1 => driver.FindElement(By.Id("workshop-1"));
        private List<IWebElement> OrderTableItems => driver.FindElements(By.CssSelector(".order-summary tbody tr")).ToList();

        private SelectElement lunchSelect(IWebElement includeLunchDropdown)
        {
            return new SelectElement(includeLunchDropdown);
        }

        public void EnterName(string name)
        {
            Name.SendKeys(name);
        }

        public void ClickAddButton()
        {
            AddButton.Click();
        }

        public string GetTotalPrice()
        {
            return TotalPrice.Text;
        }

        public void EnterNotes(string notes)
        {
            Notes.SendKeys(notes);
        }

        public void SelectWorkshop(int workshopIndex)
        {
            Workshops[workshopIndex].Click();
        }

        public string CheckUrl()
        {
            driver.Navigate().Refresh();
            return driver.Url;
        }

        public int EntryCount()
        {
            return driver.FindElements(By.CssSelector("tbody tr")).Count();
        }

        public void DoubleClickAddButton()
        {
            var action = new Actions(driver);
            action.DoubleClick(AddButton).Perform();
        }

        public bool IsValidationErrorDisplayed()
        {
            return driver.FindElement(By.Id("full-name_validation-error")).Displayed;
        }

        public void CoordinatesClick()
        {
            var actions = new Actions(driver);
            actions.MoveByOffset(AddButton.Location.X + 5, AddButton.Location.Y + 5).Click().Perform();
            actions.ContextClick(AddButton);
        }

        public string UsingSendKeysAndClearTest()
        {
            TextArea.SendKeys("Will arrive a bit late.");
            TextArea.Clear();
            TextArea.SendKeys("5% discount");
            return TextArea.GetAttribute("value");
        }

        public string PhotoUpload()
        {
            PhotoInput.SendKeys(Path.GetFullPath(Path.Join("data", "Caizar.jpg")));
            return PhotoInput.GetAttribute("value");
        }

        public void pressingKeys()
        {
            var actions = new Actions(driver);
            actions.Click(Name)
                .SendKeys(Keys.End)
                .KeyDown(Keys.Shift)
                .SendKeys(Keys.Home)
                .SendKeys(Keys.Backspace)
                .Perform();
        }

        public void SelectingDropdownOptionbyText()
        {
            lunchSelect(lunchDropDown).SelectByText("Yes");
        }

        public void SelectingDropdownOptionbyValue()
        {
            lunchSelect(lunchDropDown).SelectByValue("false");
        }

        public string LunchSelectionAttribute()
        {
            return lunchSelect(lunchDropDown).SelectedOption.GetAttribute("value");
        }

        public string LunchSelectionText()
        {
            return lunchSelect(lunchDropDown).SelectedOption.Text;
        }

        public void SelectingCheckboxItem()
        {
            if (!Workshop1.Selected)
            {
                Workshop1.Click();
            }
        }

        public bool SelectedWorkshop1()
        {
            return Workshop1.Selected;
        }

        public OrderStatusPage ClickOrderButton()
        {
            OrderButton.Click();
            return new OrderStatusPage(driver);
        }

        public void ScrollToTheOrderButton()
        {
            ScrollToElement(OrderButton);
        }

        public void ClickOnTheTicketRemoveButton(int index)
        {
            OrderTableItems[index].FindElement(By.TagName("button")).Click();
        }

        public int GetOrderTicketsCount()
        {
            return OrderTableItems.Count;
        }

        public void ScrollToTicketRemoveButton(int index)
        {
            ScrollToElement(OrderTableItems[index]);
        }

        public string GetNameValue()
        {
            return Name.GetAttribute("value");
        }
    }
}