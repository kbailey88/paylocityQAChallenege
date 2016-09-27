using paylocityQAChallenge.Common.Implementation;
using paylocityQAChallenge.Common.Interface;
using paylocityQAChallenge.PageObjects.Implementation;
using paylocityQAChallenge.PageObjects.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace paylocityQAChallenge.Specflow.Steps
{
    [Binding]
    public sealed class BenefitsDashboardTests
    {
        private static IWebDriver driver
        {
            set { ScenarioContext.Current.Set(value, "WebDriver"); }
            get { return ScenarioContext.Current.Get<IWebDriver>("WebDriver"); }
        }

        private readonly IBenefitsDashboard _benefitsDashboard;
        private readonly IAddEditEmployee _addEditEmployee;
        private readonly IBenefitsCalculator _benefitsCalculator;

        public BenefitsDashboardTests()
        {
            IBenefitsDashboard benefitsDashboard = new BenefitsDashboard();
            IAddEditEmployee addEditEmployee = new AddEditEmployee();
            IBenefitsCalculator benefitsCalculator = new BenefitsCalculator();

            _benefitsDashboard = benefitsDashboard;
            _addEditEmployee = addEditEmployee;
            _benefitsCalculator = benefitsCalculator;
        }

        #region Given Steps
        [Given(@"I click the add employee button")]
        public void GivenIClickTheAddEmployeeButton()
        {
            _benefitsDashboard.ClickAddEmployee(driver);
            System.Threading.Thread.Sleep(5000);
        }

        #endregion
        
        #region When Steps
        [Given(@"I set the First Name to (.*)")]
        [When(@"I set the First Name to (.*)")]
        [Then(@"I set the First Name to (.*)")]
        public void ThenISetTheFirstNameTo(string firstName)
        {
            _addEditEmployee.SetFirstName(firstName, driver);
        }

        [Given(@"I set the Last Name to (.*)")]
        [When(@"I set the Last Name to (.*)")]
        public void GivenISetTheLastNameTo(string lastName)
        {
            _addEditEmployee.SetLastName(lastName, driver);
        }

        [Given(@"I set the number of dependents to (.*)")]
        [When(@"I set the number of dependents to (.*)")]
        public void GivenISetTheNumberOfDependentsTo(int numOfDependents)
        {
            _addEditEmployee.SetDependents(numOfDependents, driver);
        }

        [When(@"I click the delete button for user (.*) (.*)")]
        public void WhenIClickTheDeleteButtonForUser(string firstName, string lastName)
        {
            _benefitsDashboard.ClickDeleteByValue(firstName + " " + lastName, driver);
        }


        [When(@"I click the edit employee button for (.*) (.*)")]
        public void WhenIClickTheEditEmployeeButtonFor(string firstName, string lastName)
        {
            _benefitsDashboard.ClickEditByValue(firstName + " " + lastName, driver);
            System.Threading.Thread.Sleep(2000);
        }

        #endregion

        #region Then Steps

        [Given(@"I click the Submit button")]
        [When(@"I click the Submit button")]
        [Then(@"I click the Submit button")]
        public void ThenIClickTheSubmitButton()
        {
            _addEditEmployee.ClickSubmit(driver);
        }

        [Given(@"the Employee with the correct cost and pay and the following details appears")]
        [Then(@"the Employee with the correct cost and pay and the following details appears")]
        public void ThenTheEmployeeWithTheCorrectCostAndPayAndTheFollowingDetailsAppears(Table table)
        {
            IList<IWebElement> employeeDetails = _benefitsDashboard.GetEmployeeDetailsByFirstLastName(table.Rows[0]["FirstName"], table.Rows[0]["LastName"], driver);
            //Assert.AreEqual(table.Rows[0]["LastName"], employeeDetails[1].Text);
            //Assert.AreEqual(table.Rows[0]["FirstName"], employeeDetails[2].Text);
            Assert.AreEqual(table.Rows[0]["Salary"], employeeDetails[3].Text);
            Assert.AreEqual(table.Rows[0]["Dependents"], employeeDetails[4].Text);
            Assert.AreEqual(table.Rows[0]["GrossPay"], employeeDetails[5].Text);
            Assert.AreEqual(_benefitsCalculator.GetBenefitCost(Convert.ToDecimal(table.Rows[0]["Salary"]), 1000, 500, Convert.ToInt32(table.Rows[0]["Dependents"])).ToString(), employeeDetails[6].Text);
            Assert.AreEqual(_benefitsCalculator.GetNetPay(Convert.ToDecimal(table.Rows[0]["Salary"]), 1000, 500, Convert.ToInt32(table.Rows[0]["Dependents"])).ToString(), employeeDetails[7].Text);
            System.Threading.Thread.Sleep(2000);
        }

        
        [Then(@"the employee (.*) (.*) is removed from the benefits table")]
        public void ThenTheEmployeeIsRemovedFromTheBenefitsTable(string firstName, string lastName)
        {
            _benefitsDashboard.VerifyEmployeeNotInBenefitsTable(firstName, lastName, driver);
        }
        
        #endregion
    }
}
