Feature: subscriptionMoDMedalResearchOffice
	

Scenario Outline: reader ticket
	Given I am on reader ticket demo page
	When I click on reder ticket demo button and enter "<barcodeNumber>"
	Then I should see Subscription(MoD Medal Research Office) in the home page
	Examples: 
	| barcodeNumber |
	| 110110        |              
