using OpenQA.Selenium;
using System.Collections.Generic;

namespace paylocityQAChallenge.PageObjects.Interface
{
    public interface IBenefitsDashboard
    {
        string GetBannerInnerText(IWebDriver driver);

        IList<IWebElement> GetEmployeeDetailsByRow(int row, IWebDriver driver);

        IList<IWebElement> GetEmployeeDetailsByID(string employeeID, IWebDriver driver);

        IList<IWebElement> GetEmployeeDetailsByFirstLastName(string firstName, string lastName, IWebDriver driver);

        void VerifyEmployeeNotInBenefitsTable(string firstName, string lastName, IWebDriver driver);

        void ClickAddEmployee(IWebDriver driver);

        void ClickDeleteByValue(string valueToUse, IWebDriver driver);

        void ClickEditByValue(string valueToUse, IWebDriver driver);
    }
}
