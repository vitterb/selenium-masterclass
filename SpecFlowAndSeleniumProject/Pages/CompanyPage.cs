using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowAndSeleniumProject.Pages
{
    internal class CompanyPage : BasePage
    {
        public CompanyPage(IWebDriver driver) : base(driver)
        {
        }

        // IWebElements

        private IWebElement CompanyNameInputField => _driver.FindElement(By.Id("companyName"));
        private IWebElement AddCompanyButton => _driver.FindElement(By.Id("addCompany"));
        private IWebElement GetCompaniesRowByName(string companyName) => _wait.Until(driver => driver.FindElements(By.CssSelector(".CompanyName")).FirstOrDefault(e => e.Text.Trim() == companyName));
        private IWebElement GetDeleteButtonForUser(string companyName)
        {
            var companyRow = GetCompaniesRowByName(companyName);
            var parentLi = companyRow.FindElement(By.XPath("./ancestor::li[1]"));
            return parentLi.FindElement(By.CssSelector(".deleteButton"));
        }

        // Methods

        public void AddCompanyName(string companyName) => CompanyNameInputField.SendKeys(companyName);
        
        public void ClickAddCompanyButton() => AddCompanyButton.Click();

        public string CompanyRowByName(string companyName) => GetCompaniesRowByName(companyName).Text.Trim();

        public void ClickDeleteButtonForCompany(string companyName) => GetDeleteButtonForUser(companyName).Click();

        public bool IsUserVisibleInTable(string CompanyName)
        {
            bool isCompanyPresent = true;
            try
            {
                _wait.Until(driver =>
                {
                    var companies = driver.FindElements(By.XPath($"//td[text()='{CompanyName}']"));
                    isCompanyPresent = companies.Any() && companies.First().Displayed;
                    return !isCompanyPresent;
                });
            }
            catch (WebDriverTimeoutException)
            {
                isCompanyPresent = true;
            }
            return isCompanyPresent;
        }

    }
}
