Feature: manorSearch
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario Outline: verify Record creators
	Given I am on manor search page
	When I go to Search by Manor, enter "<manorName>" and select "<historicCountry>"
	Then check for Records should be zero and Record creators shouldn't be zero
	And place should be "<historicCountry>"

	Examples:
		| manorName | historicCountry |
		| *         | Cambridgeshire  |
		| *         | Denbighshire    |
		| *         | Glamorgan       |

Scenario Outline: Manorial documents keyword search And Date Range
	Given I am on manor search page
	When I go to search for manorial documents, enter "<allOfTheseWords>","<historicCountry>","<typesOfDocument>","<from>","<to>"
	Then check for "<typesOfDocument>" in the results and  Date is in the range "<from>","<to>" and record creators shoul be zero

	Examples:
		| allOfTheseWords | historicCountry | typesOfDocument | from | to   |
		| *               | Berkshire       | extent          | 1500 | 1860 |
		| *               | Dorset          | enfranchisement | 1300 | 1900 |
		| *               | Middlesex       | valuation       | 1300 | 1700 |

