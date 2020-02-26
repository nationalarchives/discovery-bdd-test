Feature: DetailPage 

Scenario Outline: DetailPage_Feedback_NO
	Given I am on details page for "<iaId>"
	When click on NO for could this page be improved?
	And check for the title Your feedback helps us improve our services. Please share any comments below (optional).
	And click on send
	Then check for the title Thank you for your feedback

	Examples:
		| iaId      |
		| D32670    |
		| N13780091 |

Scenario Outline: DetailPage_Feedback_Yes
	Given I am on details page for "<iaId>"
	When click on YES for could this page be improved?
	And click on "<checkBox>" under please let us know why you are dissatisfied
	And click on send
	Then check for the title Thank you for your feedback

	Examples:
		| iaId      | checkBox             |
		| N13959850 | did-not-understand   |
		| N13780091 | too-much-information |
		| N13759454 | expected-the-record  |

Scenario Outline: DetailPage_letUsKnow
	Given I am on details page for "<iaId>"
	When click on "letUsKnow" under catalogue description
	And I enter fieldContainsError "<fieldContainsError>"
	#And enter info "<fieldContainsError>","<whatIsTheError>","<correctInformation>","<name>" and "<email>"
	And I enter info
		| whatIsTheError | correctInformation | name   | email                     |
		| Test check     | Test check correct | Tester | tnadiscovery100@gmail.com |
	Then check for the message Thank you for taking time to submit a suggestion

	Examples:
		| iaId      | fieldContainsError   |
		| N13780091 | Creator              |
		| C3091668  | Physical description |
		| D6343342  | Former references    |

Scenario Outline: DetailPage_ShowImages_Offsite
	Given I am on details page for offsite "<iaId>"
	When click on preview an image of this record
	Then check for the title To download this record without a watermark please add it to your basket

	Examples:
		| iaId     |
		| C4236021 |
		| C4235988 |

Scenario Outline: DetailPage_ShowImages_staffin
	Given I am on details page for staffin "<iaId>"
	When click on preview an image of this record
	Then I shouldn't see the message To download this recordwithout watermark please add it to your basket

	Examples:
		| iaId     |
		| C4236021 |
		| C4235988 |

Scenario Outline: Verify_DetailPage_OnAllLevels
	Given I am on details page for offsite "<iaId>"
	When  verify the reference On Department level
	And  verify the reference on Division level
	And verify series level
	And verify Subseries level
	And verify subsubseries level
	Then I shouls verify Piece level and item level

	Examples:
		| iaId |
		| C252 |

Scenario Outline: Verify_DetailPage_OnSeriesLevel
	Given I am on details page for offsite "<iaId>"
	When I enter all these "<firstName>", "<lastName>"
	Then check for "<firstName>","<lastName>" from the first record and check "<filter>"

	Examples:
		| iaId   | firstName | lastName | filter  |
		| C12122 | John      | Taylor   | PROB 11 |
		| C1848  | George    | William  | ADM 139 |
		| C14576 | Thomas    | Allen    | WO 372  |

Scenario Outline: Verify_DetailPage_OnSeriesLevel_Validation
	Given I am on details page for offsite "<iaId>"
	When I enter charcters in "<fromDate>", "<toDate>"
	Then check for the validation message You have entered invalid date format

	Examples:
		| iaId   | fromDate | toDate |
		| C12122 | George   | Mary   |
		| C1848  | Abraham  | Royal  |