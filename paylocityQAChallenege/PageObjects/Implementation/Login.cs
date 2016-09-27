using paylocityQAChallenge.PageObjects.Interface;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace paylocityQAChallenge.PageObjects.Implementation
{
    class Login : ILogin
    {
        public void ClickLoginButton(IWebDriver driver)
        {
            driver.FindElement(By.Id("btnLogin")).Click();
        }


        public string GetLoginButtonText(IWebDriver driver)
        {
            IWebElement buttonText = driver.FindElement(By.Id("btnLogin"));
            return buttonText.Text;
        }

        public IWebDriver LaunchHomepage()
        {
            IWebDriver driver;
            string location = "file:///C:/Users/Keenan/Downloads/Paylocity%20QA%20Interview%20Challenge/login.html";
            driver = new ChromeDriver(@"C:\Users\Keenan\Downloads\chromedriver_win32");
            driver.Navigate().GoToUrl(location);
            return driver;
        }

        public void SetPassword(string password, IWebDriver driver)
        {
            IWebElement usernameTextBox = driver.FindElement(By.Name("form-password"));
            usernameTextBox.SendKeys(password);
        }

        public void SetUsername(string username, IWebDriver driver)
        {
            IWebElement usernameTextBox = driver.FindElement(By.Name("form-username"));
            usernameTextBox.SendKeys(username);
        }

        public string GetValidationErrors(IWebDriver driver)
        {
            IWebElement validationErrors = driver.FindElement(By.Id("validation-errors"));
            return validationErrors.Text;
        }
    }
}
