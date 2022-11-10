Feature: User access AddToCart functionality


Scenario: verify user can do AddToCart functionality
	Given user in the login page
	When user enter username and password
		| Username      | Password     |
		| standard_user | secret_sauce |
	When user clicks on the login button
	Then user navigate to home page
	When user clicks on the selected product addToCart button
	Then user can see selected product add to the cart icon

Scenario: verify user can remove the product from the cart functionality
	Given user in the login page
	When user enter username and password
		| Username      | Password     |
		| standard_user | secret_sauce |
	When user clicks on the login button
	Then user navigate to home page
	When user clicks on the selected product addToCart button
	Then user can see selected product add to the cart icon
	When user clicks on cart icon
	Then user can see his own cart
	When user clicks on the product Remove button
	Then user can see selected product removed from the list