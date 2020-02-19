Feature: tagOnTest

Scenario Outline: Add Tag
	Given I am on discovery details page for staffin "<iaId>", signed in
	When I enter "<tag>", click on Add tag
	Then check for the message your tag has been added

	Examples:
		| iaId      | tag                      |
		| C7351413  | testing for somethingggg |
		| C4216021  | Test1                    |
		| D32670    | Test2                    |

Scenario Outline: Delete tag
	Given I am on discovery details page for staffin "<iaId>", signed in
	When click on delete tag
	Then check for the message your tag has been deleted

	Examples:
		| iaId     |
		| C7351413 |

Scenario Outline: Duplicate add tag and tag for two or lessathan two characters
	Given I am on discovery details page for staffin "<iaId>", signed in
	When we add "<tag>" couple of times
	Then check the message An error occurred when processing your request to add this tag

	Examples:
		| iaId     | tag              |
		| C7351413 | testDuplicateTag |
		| C4216021 | ad               |

Scenario Outline: MAx Tag Length
	Given I am on discovery details page for staffin "<iaId>", signed in
	When I enter "<tag>", click on Add tag
	Then check for the message your tag has been added
	And click on delete tag

	Examples:
		| iaId     | tag                                    |
		| C7351413 | Ingeneraltestingfindingsomethingworkss |

Scenario Outline: SelfTagRemovalRequestNoSignIn
	Given I am on discovery details page for staffin "<iaId>"
	When click on flag, enter "<reason>", "<name>", "<email>"
	Then check for the message Thank you for submitting a tag removal request. If you left contact details, a member of our team will be in touch soon

	Examples:
		| iaId     | reason                      | name   | email                     |
		| C7351413 | Testing tag removal request | Tester | tnadiscovery100@gmail.com |

Scenario Outline: stop list tag
	Given I am on discovery details page for staffin "<iaId>", signed in
	When enter "<tag>" from the stop list
	Then check the message An error occurred when processing your request to add this tag

	Examples:
		| iaId     | tag   |
		| C7351413 | abuse |

