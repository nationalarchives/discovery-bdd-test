Feature: AdvancedSearch_Records
	testing all the scenarios under records tab under Advanced Search

Background: Opening browser and go to advanced search
	Given Open chrome and Navigate to Discovery Advanced Search

Scenario:AS_AutoLookUp_ByGovernmentDepartment
Held by and Records by government department creators
	When enter "test" and click on TNA and enter "Gov" and I click on AX Local Government Boundary Commission for England
	Then I can see the filters The national archives and filters with gov

Scenario: AS_AutoLookUp_OtherArchives
Other Archives
	When enter "*" and click on other archives and I typed "Glou" and click on Collection held privately enquiries to Gloucestershire Archives
	Then I can see the filters Other archives and Gloucestershire Archives

Scenario Outline: AS_ClosureStatus_close_SpecificDate
Closed Document and Specific Date
	When typed "*" and click on TNA and click on all records
	And enter <date> for on a specific date and click on closed Document And check for the filters TNA and Closed Document and click on the first record
	Then Check for <date> Records Opening Date is same as above

	Examples:
		| date       |
		| 01/01/2050 |
		| 01/01/2060 |

Scenario Outline: AS_ClosureStatus_Open_SpecificDate
Record Opened on specific date
	When typed "*" and click on TNA and click on all records
	And I click on specific date and typed <date> and click on Open Document and check for the filters TNA and Open Document and click on the first record
	Then Check for <date> Records Opening Date is same as above

	Examples:
		| date       |
		| 03/07/2007 |
		| 01/01/2000 |
		| 01/03/2008 |

Scenario: AS_ClosureStatus_PartiallyOpen_AnyTime
Partially Opened records
	When typed "*" and click on TNA and click on all records and on partially open checkbox under Record closure status
	Then Check for the filter Partially Open and zero Records

Scenario:AS_ClosureStatus_Retained_AnyTime
Retained Documents
	When typed "*" and click on TNA and click on all records and click on Retained Document under Record closure status
	And Check for the filter Retained Document and click on the first record
	Then check for the closure status: Retained Document

Scenario Outline:AS_Records_DateRange_SearchAll
Search all for 'Held by'
	When enter these "<AllOfTheseWords>", "<AnyOfTheseWords>", "<FromDate>" and "<ToDate>"
	Then check all the records contains "<AllOfTheseWords>" and "<AnyOfTheseWords>"
	And check the third record is in the range "<FromDate>" and "<ToDate>"

	Examples:
		| AllOfTheseWords | AnyOfTheseWords | FromDate | ToDate |
		| Nelson          | mandela         | 1900     | 2000   |
		| George          | Robert          | 1850     | 1950   |
		| David           | Evans           | 1300     | 1500   |

Scenario:AS_Records_SearchTNA_CatalogueLevel
CatalogueLevel and Exclude Title
	When typed "*" and click on TNA and click on all records
	And check all the Catalogue levels and Exclude title
	Then the records shouldn't be zero

Scenario Outline:AS_Records_SearchTNA_Reference_IncludeContent
Include content
	When typed "*", enter "<SearchForReferences>", click on TNA, click on All records, click on Include content
	Then check for the filter "<SearchForReferences>"

	Examples:
		| SearchForReferences |
		| CAB 181             |
		| ED 151              |
		| ECG 3               |

# This scenario works with elastic search
#Scenario: AS_Records_SearchTNA_Taxonomy_Witchcraft
#Taxonomy subjects
#	When typed "*", click on TNA, Click on All records and click on Witchcraft
#	Then check the third record contains witchcraft

Scenario Outline: AS_Records_SpecificDate_SearchAll
Search a specific Date
	When typed "<AllOfTheseWords>" , "<AnyOfTheseWords>", "<SpecificDate>"
	Then check for the filter contains "<SpecificDate>"
	And check the second record contains "<AllOfTheseWords>" , "<AnyOfTheseWords>"

	Examples:
		| AllOfTheseWords | AnyOfTheseWords | SpecificDate |
		| Nelson          | Mandela         | 1986         |
		| George          | William         | 1900         |

Scenario Outline: AS_Reference_SearchAll
Any of these References
	When enter "<Reference>"
	Then check in the third record for "<Reference>"

	Examples:
		| Reference |
		| IR 30     |
		| WO 95     |

Scenario Outline: AS_Search_Find_DontFindWord
	When enter "<allOfTheseWords>","<exactWordOrPhase>" and Search
	Then I should see the "<exactWordOrPhase>"
	When I click on AdvancedSearch again and enter "<dontFindAnyOfTheseWords>"
	Then I shouldn't see "<dontFindAnyOfTheseWords>"

	Examples:
		| allOfTheseWords | exactWordOrPhase | dontFindAnyOfTheseWords |
		| David           | John             | Morgan                  |
		| George          | Anne             | ship                    |

Scenario:  AS_SearchOtherArchives
	When I enter "*" and click on other archives
	Then I should see the filter Other Archives and Records shouldn't be zero