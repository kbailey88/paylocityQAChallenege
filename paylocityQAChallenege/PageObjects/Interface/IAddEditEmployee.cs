using OpenQA.Selenium;

namespace paylocityQAChallenge.PageObjects.Interface
{
    public interface IAddEditEmployee
    {
        void SetFirstName(string firstName, IWebDriver driver);

        void SetLastName(string lastName, IWebDriver driver);

        void SetDependents(int numOfDependents, IWebDriver driver);

        void ClickSubmit(IWebDriver driver);

        void ClickClose(IWebDriver driver);
    }
}
