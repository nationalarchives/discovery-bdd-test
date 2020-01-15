Feature: BrowseOnTest

Background:
	Given I am on the browse page

Scenario Outline: Browse_Archives
	When I click on "<alphabet>" under Browse archives
	Then check for the first title starts with "<alphabet>"

	Examples:
		| alphabet |
		| N        |
		| T        |
		| S        |

Scenario Outline: Record_Creators
	When click on "<recordCreatorsType>"
	Then click on the "<alphabet>" under record creators
	And check for the title starts with "<recordCreatorsType>","<alphabet>"

	Examples:
		| recordCreatorsType | alphabet |
		| Family             | L        |
		| Organisation       | A        |
		| Manor              | K        |

Scenario Outline: Records_Of_OtherArchives
	When click on "<letter>" under Records of other archives
	Then check the title starts with "<letter>"

	Examples:
		| letter |
		| F      |
		| K      |
		| R      |

Scenario Outline: Records_Of_TNA
	When click on "<letter>" under Records of the National Archives
	Then check the second record title starts with "<letter>"

	Examples:
		| letter |
		| S      |
		| T      |
		| L      |