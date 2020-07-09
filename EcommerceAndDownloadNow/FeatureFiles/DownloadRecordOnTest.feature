Feature: DownloadRecords_afterSignedIn

Scenario Outline: Verify_DownloadOption_LargeFiles_ForOffsite
	Given I am on download page for offsite "<iaId>" and signedIn
	When I add to basket,submit order, pay using paypal
	Then check for the message Thank you for your order and check we are able to Download

	Examples:
		| iaId     |
		| C7351413 |
		| C7354941 |

Scenario Outline: Verify_DownloadOption_InAccount
	Given I am on download page for offsite "<iaId>" and signedIn
	When I add to basket,submit order, pay using paypal
	Then go to your orders in the account and check for the "<orderDetails>"
	And check we are able to download

	Examples:
		| iaId     | orderDetails             |
		| D16877   | Will of William Climance |
		| D8436688 | Squadron Number          |

Scenario Outline: Verify_DownloadOption_OnConfirmationPage_staffIn
	Given I am on download page for staffin "<iaId>"
	When signedIn
	Then check we are able to download

	Examples:
		| iaId    |
		| D744951 |
		| D859666 |