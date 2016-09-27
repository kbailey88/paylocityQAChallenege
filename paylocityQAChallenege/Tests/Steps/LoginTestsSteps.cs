using paylocityQAChallenge.PageObjects.Implementation;
using paylocityQAChallenge.PageObjects.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace paylocityQAChallenge.Specflow
{
    [Binding]
    public sealed class LoginTests
    {
        private static IWebDriver driver
        {
            set { ScenarioContext.Current.Set(value, "WebDriver"); }
            get { return ScenarioContext.Current.Get<IWebDriver>("WebDriver"); }
        }
        private readonly ILogin _login;
        private readonly IBenefitsDashboard _benefitsDashboard;

        public LoginTests()
        {
            ILogin login = new Login();
            IBenefitsDashboard benefitsDashboard = new BenefitsDashboard();

            _login = login;
            _benefitsDashboard = benefitsDashboard;
        }

        #region Given Steps
        [Given(@"I have launched the Benefits Login")]
        public void GivenIHaveLaunchedTheBenefitsLogin()
        {
            driver = _login.LaunchHomepage();
        }

        #endregion

        #region When Steps
        [When(@"I enter the username (.*)")]
        public void WhenIEnterTheUsername(string userName)
        {
            _login.SetUsername(userName, driver);
        }

        [When(@"then password (.*)")]
        public void WhenThenPassword(string password)
        {
            _login.SetPassword(password, driver);
        }

        [When(@"I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            _login.ClickLoginButton(driver);
        }
        #endregion

        #region Then Steps
        [Then(@"the Benefits Dashboard should be displayed")]
        public void ThenTheBenefitsDashboardShouldBeDisplayed()
        {
            Assert.AreEqual("Benefits Dashboard", _benefitsDashboard.GetBannerInnerText(driver));
        }

        [Then(@"the invalid login attempt error message should be displayed")]
        public void ThenTheInvalidLoginAttemptErrorMessageShouldBeDisplayed()
        {
            Assert.AreEqual("Invalid login attempt. Please try again.", _login.GetValidationErrors(driver));
        }

        [Then(@"the invalid password error message should be displayed for (.*)")]
        public void ThenTheInvalidPasswordErrorMessageShouldBeDisplayedFor(string userName)
        {
            Assert.AreEqual("The password is incorrect for username " + userName, _login.GetValidationErrors(driver));
        }

        #endregion
    }
}
