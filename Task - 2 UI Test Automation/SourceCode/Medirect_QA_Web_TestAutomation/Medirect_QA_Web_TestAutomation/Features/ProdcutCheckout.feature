Feature: Prodcut Checkout Functionality

Scenario: verify user successfully checkout the product
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
	When user clicks on the checkout button
	Then user can see personal information page
	When user add following details
		| Firstname     | Lastname		 | Postalcode |
		| Malinda		| Wickramasuriya | 11010      |
	When user clicks on the continue button
	Then user can see add information overview
	When user clicks on the finish button
	Then user navigate to complete page

Scenario: verify user select multiple products for checkout functionality
	Given user in the login page
	When user enter username and password
		| Username      | Password     |
		| standard_user | secret_sauce |
	When user clicks on the login button
	Then user navigate to home page
	When user clicks on the multiple as "2" selected product addToCart button
	Then user can see multiple selected product add to the cart icon
	When user clicks on cart icon
	Then user can see his own cart
	When user clicks on the checkout button
	Then user can see personal information page
	When user add following details
		| Firstname     | Lastname		 | Postalcode |
		| Malinda		| Wickramasuriya | 11010      |
	When user clicks on the continue button
	Then user can see add information overview
	When user clicks on the finish button
	Then user navigate to complete page
	

Scenario: verify user validate required information in checkout process
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
	When user clicks on the checkout button
	Then user can see personal information page
	When user clicks on the continue button
	Then user can see field validation
	
