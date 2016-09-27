using paylocityQAChallenge.PageObjects.Interface;
using OpenQA.Selenium;

namespace paylocityQAChallenge.PageObjects.Implementation
{
    class AddEditEmployee : IAddEditEmployee
    {
        public void ClickClose(IWebDriver driver)
        {
            driver.FindElement(By.XPath("//button[.='Close']")).Click();
        }

        public void ClickSubmit(IWebDriver driver)
        {
            driver.FindElement(By.XPath("//button[.='Submit']")).Click();
        }

        public void SetDependents(int numOfDependents, IWebDriver driver)
        {
            var temp = driver.FindElements(By.ClassName("form-control"));
            temp[2].Clear();
            temp[2].SendKeys(numOfDependents.ToString());
        }

        public void SetFirstName(string firstName, IWebDriver driver)
        {
            var temp = driver.FindElements(By.ClassName("form-control"));
            temp[0].Clear();
            temp[0].SendKeys(firstName);
        }

        public void SetLastName(string lastName, IWebDriver driver)
        {
            var temp = driver.FindElements(By.ClassName("form-control"));
            temp[1].Clear();
            temp[1].SendKeys(lastName);
        }
    }
}
