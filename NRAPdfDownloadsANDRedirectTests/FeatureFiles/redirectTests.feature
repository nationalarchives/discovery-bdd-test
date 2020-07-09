Feature: redirectTests
	

Scenario: redirect A2A
	Given I am on redirect A2A page
	When I check the title
	Then the title should be Talbot Papers

Scenario: redirect NRA
Given I am on redirect NRA page
When I check the title
Then the title should be national archives
