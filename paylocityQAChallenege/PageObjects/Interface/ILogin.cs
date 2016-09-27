using OpenQA.Selenium;

namespace paylocityQAChallenge.PageObjects.Interface
{
    public interface ILogin
    {
        IWebDriver LaunchHomepage();

        void SetUsername(string username, IWebDriver driver);

        void SetPassword(string password, IWebDriver driver);

        void ClickLoginButton(IWebDriver driver);

        string GetLoginButtonText(IWebDriver driver);

        string GetValidationErrors(IWebDriver driver);
    }
}
