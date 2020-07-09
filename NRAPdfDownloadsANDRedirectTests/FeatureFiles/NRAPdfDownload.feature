Feature: NRAPdfDownload

Scenario: Pdf Download
	Given I am on NRA pdf download page
	When I check page status
	Then status code should be OK

Scenario: Pdf Download_anotherIaid
	Given I am on NRA PDF for another IAID
	When  I check page status
	Then status code should be OK