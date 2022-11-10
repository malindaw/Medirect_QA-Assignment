Feature: About Page Functionality

Scenario: verify user can navigate to About page functionality
	Given user in the login page
	When user enter username and password
		| Username      | Password     |
		| standard_user | secret_sauce |
	When user clicks on the login button
	Then user navigate to home page
	When user clicks on main menu
	And  user click on the "About" option in main menu 
	Then user will navigate to about page