Feature: Product Sort Functionality

Scenario: verify user sort products from Z to A functionality
	Given user in the login page
	When user enter username and password
		| Username      | Password     |
		| standard_user | secret_sauce |
	When user clicks on the login button
	Then user navigate to home page
	When user select "Name (Z to A)" option in the sort dropdown
	Then user can see products are sorted in "decending" order 

Scenario: verify user sort products from A to Z functionality
	Given user in the login page
	When user enter username and password
		| Username      | Password     |
		| standard_user | secret_sauce |
	When user clicks on the login button
	Then user navigate to home page
	When user select "Name (A to Z)" option in the sort dropdown
	Then user can see products are sorted in "ascending" order 

Scenario: verify user sort products from Price low to high functionality
	Given user in the login page
	When user enter username and password
		| Username      | Password     |
		| standard_user | secret_sauce |
	When user clicks on the login button
	Then user navigate to home page
	When user select "Price (low to high)" option in the sort dropdown
	Then user can see products are sorted in "Price low to high" order

Scenario: verify user sort products from Price high to low functionality
	Given user in the login page
	When user enter username and password
		| Username      | Password     |
		| standard_user | secret_sauce |
	When user clicks on the login button
	Then user navigate to home page
	When user select "Price (high to low)" option in the sort dropdown
	Then user can see products are sorted in "Price high to low" order