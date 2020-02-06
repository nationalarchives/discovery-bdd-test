Feature: NRAPdfDownload
	


Scenario: Pdf Download
	Given I am on NRA pdf download page
	When I check page status
	Then status code should be OK
