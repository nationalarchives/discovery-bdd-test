Feature: DigitalDownloads

Scenario Outline: PriceZeroWhenSignedIn and basketLimitExplanation
	Given I am on digital downloads page "<iaId>"
	And check "<price>" and sign in to get this free and basketLimitExplanation
	When I signed in
	Then I should see the price should be free

	Examples:
		| iaId      | price |
		| C14023474 | 3.50  |
		| C14029175 | 3.50  |
		| C14030977 | 3.50  |

Scenario Outline: viewYourPastOrders
	Given I am on digital downloads page "<iaId>"
	When I Add to basket, check basket has the "<price>"
	And I signed in
	Then check the "<priceAfterSignedIn>", view your past orders
	And check for the message Digital downloads ordered in the last thirty days

	Examples:
		| iaId      | price | priceAfterSignedIn |
		| C14030571 | 3.50  | 0.00               |
		| C14030620 | 3.50  | 0.00               |
		| C14029919 | 3.50  | 0.00               |

Scenario: fairPolicyBannerFromHomePage
	Given I am on home page for DD tests
	And  I can see the banner
	When I click on fair policy link
	Then I should see free access to digital records page

Scenario Outline: fairPolicyBannerDetailsPage
	Given I am on digital downloads page "<iaId>"
	And  I can see the banner
	When I click on fair policy link
	Then I should see free access to digital records page

	Examples:
		| iaId     |
		| C3559849 |
		| C2503374 |
		| C3764091 |

Scenario: dataProtection
	Given I am on home page for DD tests
	When click on register
	Then I can see Data protection message in the register page