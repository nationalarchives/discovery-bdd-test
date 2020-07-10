Feature: SARServerTests

Scenario Outline: catalogue description subtitles
	Given I am on details page for SAR server "<iaID>"
	When I check the catalogue description
	Then I should see "<assetDetails1>", "<assetDetails2>","<assetDetails3>" in catalogue description

	Examples:
		| iaID                              | assetDetails1          | assetDetails2                | assetDetails3                               |
		| C14499665                         | Record opening date    | Access conditions            | Description                                 |
		#| C4220383                          | Reconsideration due in | Lord Chancellor's Instrument | LCI signed date                             |
		#| C10878728                         | Exemption 2            | FOI decision date            | Legal status                                |
		#| C10831067                         | LCI signed date        | Closure criterion            | Former reference in its original department |
		#| C9501656                          | Explanation            | FOI decision date            | Exemption                                   |
		#| C3219685                          | Closure criterion      | Lord Chancellor's Instrument | LCI signed date                             |
		| 224b9e65b97b49dd983c11e9f1b45bf4# | Exemption 1            | Exemption 3                  | Record opening date                         |
		| 5cbe4cfd2f224c0d9d88fc045b3ee5d9  | Physical description   | FOI decision date            | Exemption 2                                 |