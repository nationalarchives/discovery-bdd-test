Feature: DownloadNow_Onsite_LargeAndZipFiles

Scenario Outline: Download now for large files
	Given I am on details page for large files "<iaId>"
	When click on download now
	Then we can able to download the files

	Examples:
		| iaId    |
		| C513494 |
		| C513495 |

Scenario Outline: Download now for zip files
	Given I am on details page for large files "<iaId>"
	When click on download now for zip files
	Then we can able to download the files

	Examples:
		| iaId      |
		| C11550094 |
		| C11521866 |