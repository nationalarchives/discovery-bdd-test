Feature: AdvancedSearch_RecordCreators

Background: Opening browser and go to advanced search
	Given Navigate to Advanced Search and click on record creators tab

Scenario Outline:AS_RecordCreator_CreatorType_CheckBox_Years
Creator type and Date
	When I enter "*" , select "<CreatorType>", "<Category>" and "<SubCategory>" under record creators
	And check three date check boxes "<date1>","<date2>" and "<date3>"
	Then check for all the filters "<CreatorType>", "<Category>" and "<SubCategory>"

	Examples:
		| CreatorType  | Category                  | SubCategory            | date1         | date2       | date3       |
		| Business     | Building and construction | Builders               | Dates unknown | 1 - 999     | 1000 - 1099 |
		| Organisation | Church of England         | Central administration | 1900 - 1924   | 1800 - 1899 | 1700 - 1799 |

Scenario Outline:AS_RecordCreator_CreatorType_DateRange
   Date range
	When I enter "*" , select "<CreatorType>", "<Category>" and "<SubCategory>" under record creators
	And enter "<FromDate>" and "<ToDate>" for search a date range
	Then check for all the filters "<CreatorType>", "<Category>" and "<SubCategory>"
	And check for Description date is in the range "<FromDate>" and "<ToDate>"

	Examples:
		| CreatorType  | Category  | SubCategory | FromDate | ToDate |
		| Business     | Chemicals | Explosives  | 1900     | 2007   |
		| Organisation | Army      | Home Guard  | 1600     | 1900   |