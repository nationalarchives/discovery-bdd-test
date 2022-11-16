Feature: BasicSearch

Background:
	Given Given I am on Discovery Home page
	And click on cookies, hide this message

Scenario Outline: BS_searchWithDifferentKeyWords
	When I enter "<keyword>"
	Then results should contain "<keyword>"

	Examples:
		| keyword  |
		| James    |
		| WO 95    |
		| Fredrick |

Scenario Outline: BS_FilterResult_VerifyCollectionAndSubjects
 In the subject module C10092 is Army and C10060 is Medals
	When enter "<word>", filter by TNA
	Then check for the "<collectionModule>","<subjectsModule>" got particular number of records

	Examples:
		| word | collectionModule | subjectsModule |
		| *    | WO               | C10092         |
		| *    | BT               | C10060         |

Scenario Outline: BS_GreaterThan10000_ExportFirst1000RecordsAsHtmlCsvXml
	When I enter "<keyword>", check the total number of records and record creators are not zero
	And check for the sorting is only enabled message
	And Export results in "<selectFormat>"
	Then we are able to download and check the file that has been downloaded

	Examples:
		| keyword    | selectFormat |
		| AB         | CSV          |
		| Adam       | HTML         |
		| Department | XML          |

Scenario Outline: BS_GreaterThan10000_ExportFirst1000RecordCreatorsAsHtmlCsvXml
	When I enter "<keyword>", check the total number of records and record creators are not zero
	And go to record creators and Export results in "<selectFormat>"
	Then we are able to download and check the file that has been downloaded

	Examples:
		| keyword  | selectFormat |
		| England  | CSV          |
		| Wales    | HTML         |
		| Scotland | XML          |

Scenario Outline: BS_LessThan10000_ExportFirst1000RecordCreators_sort_AsXmlHtmlCsv
	When I enter "<keyword>", check the total number of records and record creators are not zero
	And go to record creators,select "<sortedBy>", select "<selectFormat>" under export results
	Then we are able to download and check the file that has been downloaded

	Examples:
		| keyword         | sortedBy           | selectFormat |
		| soldier         | Title - descending | CSV          |
		| prison          | Title - ascending  | HTML         |
		| Medical service | Date - descending  | XML          |

Scenario Outline: BS_LessThan10000_ExportFirst1000Records_Sort_AsXmlHtmlCsv
	When I enter "<keyword>", check the total number of records and record creators are not zero
	And go to simple view, select "<sortedBy>", select "<selectFormat>" under export results
	Then we are able to download and check the file that has been downloaded

	Examples:
		| keyword          | sortedBy          | selectFormat |
		| common wealth    | Reference         | CSV          |
		| Trade with Japan | Title - ascending | HTML         |
		| hms wolfhound    | Date - descending | XML          |
		| Robert parker    | Relevance         | HTML         |

Scenario Outline: BS_LessThan10000_ExportAllRecordsAsCSV
	When I enter "<keyword>", check the total number of records and record creators are not zero
	And go to "<recordsTab>" select "<sortedBy>", select all records as spreadsheet(CSV) under export results
	Then we are able to download and check the file that has been downloaded

	Examples:
		| keyword          | recordsTab           | sortedBy          |
		| richmond society | records-tab          | Reference         |
		| Bahamas John     | name-authorities-tab | Title - ascending |

Scenario Outline: BS_NoOfRecordsPerPage15And30And60
	When I enter "<keyword>", click on "<numberOfItemsPerPage>" on the bottom
	Then the number of records displaying per page should be "<numberOfItemsPerPage>"

	Examples:
		| keyword     | numberOfItemsPerPage |
		| commissions | 30                   |
		| Abraham     | 60                   |

Scenario: BS_RecordCreator_filterresult
	When I enter "*", go to record creators tab
	Then I can see the filters Organisation, person, business, Manor, Family, Diaries

Scenario: BS_RecordOpenedInTheLast6months
	When enter "*", filter by TNA
	And click on opened in the last six months under Record opening date
	Then click on the first record and check the record opening date should be in the last six months

Scenario: BS_RecordOpenedInTheLast12months
	When enter "*", filter by TNA
	And click on opened in the last twelve months under Record opening date
	Then click on the first record and check the record opening date should be in the last twelve months

Scenario: BS_RecordOpenedInTheLastWeek
	When enter "*", filter by TNA
	And click on opened in the last week under Record opening date
	Then click on the first record and check the record opening date should be in the last week

Scenario: BS_RecordOpenedInTheLastDay
	When enter "*", filter by TNA
	And click on opened during the last day under Record opening date
	Then click on the first record and check the record opening date should be yesterday

Scenario Outline: BS_RecordOpenedOnASpecificDate
	When enter "*", filter by TNA
	And enter "<specificDate>" under Record opening date
	Then click on the first record and check the record opening date should be "<specificDate>"

	Examples:
		| specificDate |
		| 14/08/2019   |
		| 04/04/2018   |

Scenario Outline: BS_RecordOpenedWithinADateRange
	When enter "*", filter by TNA
	And enter "<fromDate>", "<toDate>" for date range under Record opening date
	Then click on the first record and check the record opening date should be with in the range "<fromDate>", "<toDate>"

	Examples:
		| fromDate   | toDate     |
		| 01/04/2018 | 01/02/2019 |
		| 20/05/2017 | 03/10/2018 |

Scenario: BS_RecordsAndRecordCreatorsDatesUnknown
	When enter "*", I am under Records tab check for the filter Dates unknown
	Then I am under record creators tab check for the filter Dates unknown

Scenario Outline: BS_RecordOpeningDate_ExportResults
	When enter "*", filter by TNA
	And enter "<specificDate>" under Record opening date
	Then click on export results and check the downloaded file manually 
	Examples: 
	| specificDate |
	| 21/08/2020     |
	| 21/08/2019     |

