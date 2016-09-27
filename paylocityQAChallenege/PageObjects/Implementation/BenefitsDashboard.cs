using paylocityQAChallenge.PageObjects.Interface;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace paylocityQAChallenge.PageObjects.Implementation
{
    class BenefitsDashboard : IBenefitsDashboard
    {
        public void ClickAddEmployee(IWebDriver driver)
        {
            driver.FindElement(By.Id("btnAddEmployee")).Click();
        }

        public void ClickDeleteByValue(string valueToUse, IWebDriver driver)
        {
            ClickButtonById(valueToUse, "btnDelete", driver);
        }

        public void ClickEditByValue(string valueToUse, IWebDriver driver)
        {
            ClickButtonById(valueToUse, "btnEdit", driver);
        }

        private void ClickButtonById(string valueToUse, string buttonId, IWebDriver driver)
        {
            var ElementCollectionBody = driver.FindElements(By.XPath("//table[@id='employee-table']/tbody/tr"));
            var btn = ElementCollectionBody.Where(x => x.Text.Contains(valueToUse)).First();
            btn.FindElement(By.Id(buttonId)).Click();
        }

        public string GetBannerInnerText(IWebDriver driver)
        {
            return driver.FindElement(By.Id("header")).Text;
        }

        public IList<IWebElement> GetEmployeeDetailsByFirstLastName(string firstName, string lastName, IWebDriver driver)
        {
            var ElementCollectionBody = GetTable(driver);
            return ElementCollectionBody.Where(x => (x.Text.Contains(firstName) && x.Text.Contains(lastName))).First().FindElements(By.TagName("td"));
        }

        public IList<IWebElement> GetEmployeeDetailsByID(string employeeID, IWebDriver driver)
        {
            var ElementCollectionBody = GetTable(driver);
            return ElementCollectionBody.Where(x => x.Text.Contains(employeeID)).First().FindElements(By.TagName("td"));
        }

        public IList<IWebElement> GetEmployeeDetailsByRow(int row, IWebDriver driver)
        {
            IList<IWebElement> ElementCollectionBody = GetTable(driver);
            return ElementCollectionBody[row].FindElements(By.TagName("td"));
        }

        public void VerifyEmployeeNotInBenefitsTable(string firstName, string lastName, IWebDriver driver)
        {
            System.Threading.Thread.Sleep(5000);
            IList<IWebElement> tableRows = GetTable(driver);
            foreach(IWebElement row in tableRows)
            {
                Assert.IsFalse(row.Text.Contains(firstName) && row.Text.Contains(lastName));
            }
        }

        private IList<IWebElement> GetTable(IWebDriver driver)
        {
            System.Threading.Thread.Sleep(2000);
            return driver.FindElements(By.XPath("//table[@id='employee-table']/tbody/tr"));
        }
    }
}
