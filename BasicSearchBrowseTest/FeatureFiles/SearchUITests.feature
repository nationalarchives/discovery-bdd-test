Feature: SearchUITests

Background:
	Given I am on search UI home page

Scenario Outline: FromYear_ToYear_DifferentFormats_ValidationMessages
	When I enter "<invalidFromYear>" and "<invalidToYear>" on home page
	Then I can see validation messages to enter correct format for start and end dates

	Examples:
		| invalidFromYear | invalidToYear |
		| 09-1900         | 01-20000      |
		| 10.1700         | 04-1950       |

Scenario Outline: FromYear_DifferentFormats_ValidationMessages
	When I enter "<invalidFromYear>" for from year on home page
	Then I can see validation messages to enter correct format for start dates

	Examples:
		| invalidFromYear |
		| 05-1970         |
		| 08.1600         |

Scenario Outline: ToYear_DifferentFormats_ValidationMessages
	When I enter "<invalidToYear>" for to year on home page
	Then I can see validation messages to enter correct format for end dates

	Examples:
		| invalidToYear |
		| 01-19         |
		| 08.1790       |

Scenario Outline: Records_InTheRange_FromAndTo
	When I enter "<from>" and "<to>" for between fields
	Then I should see the results in the range "<from>" "<to>"

	Examples:
		| from    | to      |
		| 05/1910 | 1920    |
		#| 1500    | 1520    |
		| 1880    | 09/1950 |

Scenario Outline: Tests_AllTabs_search
	When I enter "<word>", "<heldBy>" archives
	And I enter "<from>" and "<to>" for between fields
	Then I should see "<word>","<heldBy>"
	And I should see the date in the range "<from>" "<to>"

	Examples:
		| word    | heldBy                     | from    | to      |
		| William | The National Archives only | 05/1200 | 1400    |
		| BE      | Other archives only        | 1500    | 09/1900 |

Scenario: Tests_NoInput
	When I search without entering anything in the fields
	Then I should see validation message