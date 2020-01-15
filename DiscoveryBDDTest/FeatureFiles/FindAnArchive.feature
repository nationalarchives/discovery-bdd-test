Feature: FindAnArchive

Scenario Outline: Find An Archive Using A Keyword
	Given I am on discovery home page to test find an archive
	When I enter "<country>" in the search bar
	Then Location should have "<country>"

	Examples:
		| country |
		| Greece  |
		| Rome    |
		| Canada  |

Scenario Outline: Country_moreOptions
	Given I am on discovery home page to test find an archive
	When go to more options click on "<letter>" and "<country>"
	Then  Location should have "<country>"

	Examples:
		| letter | country   |
		| A      | Australia |
		| H      | Hong Kong |

Scenario Outline: Region
	Given I am on discovery home page to test find an archive
	When I select "<region>", "<county>" under Find UK archives
	Then I should see the filter "<region>", "<county>"

	Examples:
		| region          | county       |
		| East of England | Bedfordshire |
		| North West      | Cumbria      |

Scenario Outline: Export first 1000Records
	Given I am on find an archive page
	When I search for "<searchTerm>"
	And click on exportthe first thousand records in "<selectFormat>", download
	Then check we are able to download and check the file that has been downloaded

	Examples:
		| searchTerm | selectFormat |
		| *          | CSV          |
		| England    | HTML         |
		| *          | XML          |

Scenario Outline: Export all records as CSV
	Given I am on find an archive page
	When I search for "<searchTerm>"
	And click on Export all the records as CSV download
	Then check we are able to download and check the file that has been downloaded

	Examples:
		| searchTerm |
		| London     |
		| England    |

Scenario Outline: Home nation
Given I am on find an archive page
When I choose a "<homeNation>"
And check for the filters "Special", "National","Local","University","Private"
Then Location should have "<homeNation>"
Examples: 
| homeNation |
|            |
