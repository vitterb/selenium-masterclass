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
    internal class Company
    {
        private readonly CompanyPage _companyPage;
        public Company(IWebDriver driver)
        {
            _companyPage = new CompanyPage(driver);
        }

        [Given(@"I go to the application CompanyPage")]
        public void GivenIGoToTheApplicationCompanyPage()
        {
            _companyPage.GoToCompanyPage();
        }

        [When(@"I add a new company name in the input field")]
        public void WhenIAddANewCompanyNameInTheInputField()
        {
            _companyPage.AddCompanyName("TestCompany");
        }

        [When(@"I click on the add company button")]
        public void WhenIClickOnTheAddCompanyButton()
        {
            _companyPage.ClickAddCompanyButton();
        }

        [Then(@"I should see the company in the company table")]
        public void ThenIShouldSeeTheCompanyInTheCompanyTable()
        {
            Assert.That(_companyPage.CompanyRowByName("TestCompany"), Is.EqualTo("TestCompany"));
        }

        [When(@"I click on the delete button of the company")]
        public void WhenIClickOnTheDeleteButtonOfTheCompany()
        {
            _companyPage.ClickDeleteButtonForCompany("TestCompany");
        }

        [Then(@"I should not see the company in the company table")]
        public void ThenIShouldNotSeeTheCompanyInTheCompanyTable()
        {
            Assert.IsFalse(_companyPage.IsUserVisibleInTable("TestCompany"));
        }

    }
}
