Feature: User login functionality

Scenario: verify user can successfully login to the system
	Given user in the login page
	When user enter username and password
		| Username      | Password     |
		| standard_user | secret_sauce |
	When user clicks on the login button
	Then user navigate to home page

Scenario: verify locked user functionality 
	Given user in the login page
	When user enter username and password
		| Username		  | Password     |
		| locked_out_user | secret_sauce |
	When user clicks on the login button
	Then user will get error message

Scenario: verify Problem user functionality 
	Given user in the login page
	When user enter username and password
		| Username		  | Password     |
		| problem_user    | secret_sauce |
	When user clicks on the login button
	Then user navigate to home page
	And user cannot see appropriate product picture

Scenario: verify performance glitch user functionality 
	Given user in the login page
	When user enter username and password
		| Username					 | Password     |
		| performance_glitch_user    | secret_sauce |
	When user clicks on the login button
	Then user navigate to home page

Scenario: verify user login validation 
	Given user in the login page
	When user clicks on the login button
	Then user credentials are validate

Scenario: verify user can successfully login out from the system
	Given user in the login page
	When user enter username and password
		| Username      | Password     |
		| standard_user | secret_sauce |
	When user clicks on the login button
	Then user navigate to home page
	When user clicks on main menu
	And user click on the "LogOut" option in main menu
	Then user will navigate to login page