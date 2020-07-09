Feature: CabinetPaperSearch

Background:
	Given I am on cabinetPaperSearch form

Scenario Outline: CabinetPapers_Date_descriptionOnly
	When enter "*", click on "<documentType>", "<fromDate>", "<toDate>" and select document description only
	Then check for the filters "<fromDate>" and "<toDate>"

	Examples:
		| documentType | fromDate | toDate |
		| conclusions  | 1915     | 1980   |
		| memoranda    | 1870     | 1910   |
		| notebooks    | 1600     | 2000   |

Scenario Outline: CabinetPapers_NoDate_Document_descriptionOnly
	When enter "*", click on "<documentType>" and select Document description only
	Then check for the title Return to cabinet papers website

	Examples:
		| documentType |
		| conclusions  |
		| notebooks    |
		| memoranda    |

Scenario Outline: CabinetPapers_Educationresources
	When click on Education resources tab, enter "<word>"
	Then check for the title Return to cabinet papers website

	Examples:
		| word    |
		| CAB 65  |
		| CAB 129 |
		| CAB 24  |

Scenario Outline: CabinetPapers_FilterByDifferentDocument_EntireDocument
	When enter "<word>" , "<filterByDocumentType>" and click on entire document
	Then check for the title Return to cabinet papers website

	Examples:
		| word | filterByDocumentType |
		| *    | all                  |
		| *    | memoranda            |
		| *    | precedentbooks       |
		| *    | notebooks            |