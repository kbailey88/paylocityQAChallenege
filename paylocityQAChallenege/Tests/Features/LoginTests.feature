Feature: LoginTests

Scenario: Login Happy Path
	Given I have launched the Benefits Login
	When I enter the username testUser
	And then password Test1234
	And I click the login button
	Then the Benefits Dashboard should be displayed

Scenario: Login Invalid Username
	Given I have launched the Benefits Login
	When I enter the username hb.21
	And then password Test1234
	And I click the login button
	Then the invalid login attempt error message should be displayed

Scenario: Login Invalid Password
	Given I have launched the Benefits Login
	When I enter the username testUser
	And then password badPassword
	And I click the login button
	Then the invalid password error message should be displayed for testUser