using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowAndSeleniumProject.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowAndSeleniumProject.StepDefinitions
{
    [Binding]
    internal class BaseStepDefinitions
    {
        private readonly BasePage _basePage;
        public BaseStepDefinitions(IWebDriver driver)
        {
            _basePage = new BasePage(driver);
        }

        [Then(@"I should see ""([^""]*)"" as title")]
        public void ThenIShouldSee(string expectedTitle)
        {
            Assert.That(_basePage.GetTitle(), Is.EqualTo(expectedTitle));
        }
    }
}
