using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Learning_Selenium
{
    //[Parallelizable(ParallelScope.Children)]
    //[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    internal class SimpleGloboTickets : BaseTest
    {
        [Test]
        public void SimpleTest()
        {
            GetDriver().FindElement(By.Id("full-name")).SendKeys("Josh Smith");
            GetDriver().FindElement(By.Id("add-btn")).Click();
        }

        [Test]
        public void UsingRelativeLocatorTest()
        {
            GetDriver().FindElement(RelativeBy
                .WithLocator(By.TagName("textarea"))
                .Below(By.Id("full-name")))
                .SendKeys("something important");
            GetDriver().FindElements(RelativeBy
                .WithLocator(By.CssSelector("input[type='checkbox']"))
                .Above(By.Id("add-btn")))
                .First()
                .Click();
        }

        [Test]
        public void SimpleTestWithAssertion()
        {
            GetDriver().FindElement(By.Id("full-name")).SendKeys("Josh Smith");
            GetDriver().FindElement(By.Id("add-btn")).Click();
            var totalPrice = GetDriver().FindElement(By.CssSelector("tfoot tr th:nth-child(3"));
            Assert.That(totalPrice.Text, Is.EqualTo("$100.00"), "TotalPrice is not valid");
        }

        [Test]
        public void NavigationTest()
        {
            GetDriver().Navigate().Refresh();
            Assert.That(GetDriver().Url, Contains.Substring("http://localhost:4200"));
        }

        [Test]
        public void UsingClickTest()
        {
            var nameInput = GetDriver().FindElement(By.Id("full-name"));
            nameInput.SendKeys("Josh Smith");
            var addButton = GetDriver().FindElement(By.Id("add-btn"));
            addButton.Click();
            Assert.That(GetDriver().FindElements(By.CssSelector("tbody tr")), Has.Count.EqualTo(1));
        }

        [Test]
        public void UsingDoubleClickTest()
        {
            var nameInput = GetDriver().FindElement(By.Id("full-name"));
            nameInput.SendKeys("Josh Smith");
            var addButton = GetDriver().FindElement(By.Id("add-btn"));
            var actions = new Actions(GetDriver());
            actions.DoubleClick(addButton).Perform();
            Assert.That(GetDriver().FindElement(By.Id("full-name_validation-error")).Displayed, Is.True);
        }

        [Test]
        public void CoordinatesClickTest()
        {
            var addButton = GetDriver().FindElement(By.Id("add-btn"));
            var actions = new Actions(GetDriver());
            actions.MoveByOffset(addButton.Location.X + 5, addButton.Location.Y + 5).Click().Perform();
            actions.ContextClick(addButton);
            Assert.That(GetDriver().FindElement(By.Id("full-name_validation-error")).Displayed, Is.True);
        }

        [Test]
        public void UsingSendKeysAndClearTest()
        {
            var notesTextArea = GetDriver().FindElement(By.Id("notes"));
            notesTextArea.SendKeys("Will arrive a bit late.");
            Assert.That(notesTextArea.GetAttribute("value"), Is.EqualTo("Will arrive a bit late."));
            notesTextArea.Clear();
            notesTextArea.SendKeys("5% discount");
            Assert.That(notesTextArea.GetAttribute("value"), Is.EqualTo("5% discount"));
        }

        [Test]
        public void fileUploadTest()
        {
            var photoInput = GetDriver().FindElement(By.Id("photo"));
            photoInput.SendKeys(Path.GetFullPath(Path.Join("data", "Caizar.jpg")));
            Assert.That(photoInput.GetAttribute("value"), Contains.Substring("Caizar.jpg"));
            photoInput.Clear();
            Assert.That(photoInput.GetAttribute("value"), Is.Empty);
        }

        [Test]
        public void PressingKeysTest()
        {
            var nameInput = GetDriver().FindElement(By.Id("full-name"));
            nameInput.SendKeys("Josh Smith");
            //nameInput.SendKeys(Keys.Control + "A");
            //nameInput.SendKeys(Keys.Delete);
            var actions = new Actions(GetDriver());
            actions.Click(nameInput)
                .SendKeys(Keys.End)
                .KeyDown(Keys.Shift)
                .SendKeys(Keys.Home)
                .SendKeys(Keys.Backspace)
                .Perform();
            Assert.That(GetDriver().FindElement(By.Id("full-name_validation-error")).Displayed, Is.True);
        }

        [Test]
        public void SelectingDropdownOptionTest()
        {
            var includeLunchDropdown = GetDriver().FindElement(By.Id("include-lunch"));
            var includeLunchSelectElement = new SelectElement(includeLunchDropdown);
            includeLunchSelectElement.SelectByText("Yes");
            Assert.That(includeLunchSelectElement.SelectedOption.GetAttribute("value"), Is.EqualTo("true"));
            includeLunchSelectElement.SelectByValue("false");
            Assert.That(includeLunchSelectElement.SelectedOption.Text, Is.EqualTo("No"));
        }

        [Test]
        public void SelectingCheckboxItems()
        {
            var workshop1 = GetDriver().FindElement(By.Id("workshop-1"));
            if (!workshop1.Selected)
            {
                workshop1.Click();
            }
            Assert.That(workshop1.Selected, Is.True);
        }
    }
}