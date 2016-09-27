Feature: BenefitsDashboardTests

Background:
	Given I have launched the Benefits Login
	When I enter the username testUser
	And then password Test1234
	And I click the login button

Scenario: Happy Path Add New User
	Given I click the add employee button
	And I set the First Name to John
	And I set the Last Name to Waters
	And I set the number of dependents to 1
	When I click the Submit button
	Then the Employee with the correct cost and pay and the following details appears
	| LastName | FirstName | Salary   | Dependents | GrossPay |
	| Waters   | John      | 52000.00 | 1          | 2000     |

Scenario: Happy Path Edit User
	Given I click the add employee button
	And I set the First Name to John
	And I set the Last Name to Waters
	And I set the number of dependents to 1
	And I click the Submit button
	And the Employee with the correct cost and pay and the following details appears
	| LastName | FirstName | Salary   | Dependents | GrossPay |
	| Waters   | John      | 52000.00 | 1          | 2000     |
	When I click the edit employee button for John Waters
	And I set the First Name to Bruce
	And I set the Last Name to Wayne
	And I set the number of dependents to 4
	And I click the Submit button
	Then the Employee with the correct cost and pay and the following details appears
	| LastName | FirstName | Salary   | Dependents | GrossPay |
	| Wayne    | Bruce     | 52000.00 | 4          | 2000     |

Scenario: Happy Path Delete User
	Given I click the add employee button
	And I set the First Name to Timothy
	And I set the Last Name to Hendricks
	And I set the number of dependents to 2
	And I click the Submit button
	And the Employee with the correct cost and pay and the following details appears
	| LastName  | FirstName | Salary   | Dependents | GrossPay |
	| Hendricks | Timothy   | 52000.00 | 2          | 2000     |
	When I click the delete button for user Timothy Hendricks
	Then the employee Timothy Hendricks is removed from the benefits table