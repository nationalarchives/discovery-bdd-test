Feature: deliveryOptions_2

Scenario Outline: AcademicSubscriptionStaffin
	Given I am on delivery options page "<iaId>"
	When check the "<message>" for staffin "<xPath>"
	Then check for the page "<title>"

	Examples:
		| iaId     | message                                                    | xPath                                     | title                 |
		| C2849839 | Ask a member of staff if you need help finding this record | (//div[@class='order-option-wrapper'])[1] | The National Archives |

Scenario Outline: AcademicSubscriptionOnsiteOffsite
	Given  I am on delivery options page "<iaId>"
	When  click on view delivery options presented to other users "<xPathDO>"
	And check the "<xPath>" onsite or offsite "<message>"
	Then click on the "<button>"
	And check for the page "<title>"

	Examples:
		| iaId     | xPath                                     | message                                                            | button             | title                 | xPathDO                                             |
		| C2849839 | (//div[@class='order-option-wrapper'])[2] | This record may also be available on other websites                | Adam Matthew       | The National Archives | (//a[@class='discoveryPrimaryCallToActionLink'])[3] |
		| C2849839 | (//div[@class='order-option-wrapper'])[2] | This record may also be available on other websites                | Visit Adam Matthew | The National Archives | (//a[@class='discoveryPrimaryCallToActionLink'])[3] |
		| C2849839 | (//div[@class='order-option-wrapper'])[3] | Request a quote for a copy to be sent to you via email or post (£) | Order a copy       | Page Check Request    | (//a[@class='discoveryPrimaryCallToActionLink'])[3] |

Scenario Outline: AccessUnderReviewStaffin
	Given  I am on delivery options page "<iaId>"
	When check the "<message>" for staffin "<xPath>"
	Then click on the "<button>"
	And check for the page "<title>"

	Examples:
		| iaId     | message                                             | xPath                                  | button             | title      |
		| C4216021 | This record is closed whilst access is under review | (//div[@class='order-option-wrapper']) | Submit FOI request | Freedom of Information (FOI) Request |
		| C5040641 | This record is closed whilst access is under review | (//div[@class='order-option-wrapper']) | Submit FOI request | Freedom of Information (FOI) Request |
		| C1960950 | This record is closed whilst access is under review | (//div[@class='order-option-wrapper']) | Submit FOI request | Freedom of Information (FOI) Request |

Scenario Outline: AV_Media
	Given I am on delivery options page "<iaId>"
	When check the "<message>" for staffin "<xPath>"
	Then  click on the "<button>"
	And check for the page "<title>"

	Examples:
		| iaId      | message                                 | xPath                                  | button                       | title  |
		| C14016274 | View this on the Discovery Video Player | (//div[@class='order-option-wrapper']) | Discovery Video Player       | Video: |
		| C14016274 | View this on the Discovery Video Player | (//div[@class='order-option-wrapper']) | Visit Discovery Video Player | Video: |
		| C14016322 | View this on the Discovery Video Player | (//div[@class='order-option-wrapper']) | Discovery Video Player       | Video: |
		| C14016322 | View this on the Discovery Video Player | (//div[@class='order-option-wrapper']) | Visit Discovery Video Player | Video: |

Scenario Outline: ClosedFOIReview
	Given I am on delivery options page "<iaId>"
	When check the "<message>" for staffin "<xPath>"
	Then  click on the "<button>"
	And check for the page "<title>"

	Examples:
		| iaId      | xPath                                  | message               | button             | title      |
		| C10853769 | (//div[@class='order-option-wrapper']) | This record is closed | Submit FOI request | Freedom of Information (FOI) Request |
		| C4633754  | (//div[@class='order-option-wrapper']) | This record is closed | Submit FOI request | Freedom of Information (FOI) Request |

Scenario Outline: ClosedRetainedDeptKnown
	Given I am on delivery options page "<iaId>"
	When check the "<message>" for staffin "<xPath>"
	Then  click on the "<button>"
	And check for the page "<title>"

	Examples:
		| iaId      | xPath                                  | message                                                                                       | button                                                  | title                 |
		| C11362729 | (//div[@class='order-option-wrapper']) | This record is closed and retained by Department for Business, Energy and Industrial Strategy | Visit the department website                            | The National Archives |
		| C11362729 | (//div[@class='order-option-wrapper']) | This record is closed and retained by Department for Business, Energy and Industrial Strategy | Department for Business, Energy and Industrial Strategy | The National Archives |

Scenario Outline: ClosedRetainedDeptUnKnown
	Given I am on delivery options page "<iaId>"
	When check the "<message>" for staffin "<xPath>"
	Then  click on the "<button>"
	And check for the page "<title>"

	Examples:
		| iaId     | xPath                                  | message                                            | button     | title                 |
		| C3836961 | (//div[@class='order-option-wrapper']) | This record is retained by a government department | Contact us | The National Archives |

Scenario Outline: ClosedRetainedDeptUnKnown_contactUs
	Given I am on delivery options page "<iaId>"
	When I click on contact us button
	Then check for the page "<title>"

	Examples:
		| iaId     | title                 |
		| C3836961 | The National Archives |

Scenario Outline: CollectionCareStaffin
	Given I am on delivery options page "<iaId>"
	When check the "<message>" for staffin "<xPath>"
	Then check for the page "<title>"

	Examples:
		| iaId    | message                                                                                                                          | xPath                                         | title                 |
		| C543521 | This record requires supervised handling in Collection Care                                                                      | (//div[@class='order-option-wrapper'])[1]     | The National Archives |
		| C543521 | Please contact a member of staff to arrange a viewing.                                                                           | (//div[@class='order-option-description'])[1] | The National Archives |
		| C543521 | Appointments are available from Tuesday to Friday at 11.00am or 2.00pm, are limited to two hours and are subject to availability | (//div[@class='order-option-description'])[1] | The National Archives |

Scenario Outline: CollectionCareOnSiteOffSite
	Given  I am on delivery options page "<iaId>"
	When  click on view delivery options presented to other users "<xPathDO>"
	And check the "<xPath>" onsite or offsite "<message>"
	Then click on the "<button>"
	And check for the page "<title>"

	Examples:
		| iaId    | xPath                                     | message                                                                                                                           | button     | title                 | xPathDO                                             |
		| C543521 | (//div[@class='order-option-wrapper'])[2] | This record requires supervised handling in Collection Care                                                                       |            |                       | (//a[@class='discoveryPrimaryCallToActionLink'])[2] |
		| C543521 | (//div[@class='order-option-wrapper'])[2] | Appointments are available from Tuesday to Friday at 11.00am or 2.00pm, are limited to two hours and are subject to availability. |            |                       | (//a[@class='discoveryPrimaryCallToActionLink'])[2] |
		| C543521 | (//div[@class='order-option-wrapper'])[3] | This record requires supervised handling in Collection Care                                                                       | contact    | The National Archives | (//a[@class='discoveryPrimaryCallToActionLink'])[2] |
		| C543521 | (//div[@class='order-option-wrapper'])[3] | Appointments are available from Tuesday to Friday at 11.00am or 2.00pm, are limited to two hours and are subject to availability. | Contact us | The National Archives | (//a[@class='discoveryPrimaryCallToActionLink'])[2] |

Scenario Outline: DigitizedAvailableButNotDownloadableAtItemLevel
	Given I am on delivery options page "<iaId>"
	When check the "<message>" for staffin "<xPath>"
	And click on More ways to view this record
	Then click on the "<button>"
	And check for the page "<title>"

	Examples:
		| iaId     | message                                                     | xPath                                | button       | title                 |
		| C6208104 | This record has been digitised as part of the larger record | //div[@class='order-option-wrapper'] | Go to record | The National Archives |
		| C6208104 |                                                             |                                      | Ancestry     | The National Archives |

Scenario Outline: DigitizedAvailableButNotDownloadableAtItemLevelMoreWaysToViewThisRecord
	Given I am on delivery options page "<iaId>"
	When click on More ways to view this record
	And I should see Also available from: Ancestry
	Then Hide More ways to view this record
	And I shouldn't see Also available from: Ancestry

	Examples:
		| iaId     |
		| C6208104 |

Scenario Outline: DigitizedAvailableButNotDownloadableAtPieceLevel
	Given I am on delivery options page "<iaId>"
	When check the "<message>" for staffin "<xPath>"
	And click on More ways to view this record
	Then click on the "<button>"
	And check for the page "<title>"

	Examples:
		| iaId     | message                                                    | xPath                                | button          | title                            |
		| C1905025 | This record has been digitised as part of multiple records | //div[@class='order-option-wrapper'] | Go to browse    | Browse records of other archives |
		| C1905025 |                                                            |                                      | The Genealogist | The National Archives            |
		| C1905025 |                                                            |                                      | Ancestry        | The National Archives            |

Scenario Outline: DigitizedAvailableButNotDownloadableAtPieceLevelMoreWaysToViewThisRecord
	Given I am on delivery options page "<iaId>"
	When click on More ways to view this record
	And I should see Also available from:  The Genealogist Ancestry
	Then Hide More ways to view this record
	And I shouldn't see Also available from: The Genealogist Ancestry

	Examples:
		| iaId     |
		| C1905025 |

Scenario Outline: DigitizedDiscoveryStaffin
	Given  I am on delivery options page "<iaId>"
	When check the "<message>" for staffin "<xPath>"
	Then click on the "<button>"
	And check for the page "<title>"

	Examples:
		| iaId     | message              | xPath                                  | button       | title                 |
		| C7351413 | Download this record | (//div[@class='order-option-wrapper']) | Download now | The National Archives |
		| C198022  | Download this record | (//div[@class='order-option-wrapper']) | Download now | The National Archives |

Scenario Outline: DigitizedDiscoveryOnsiteOffsite
	Given I am on delivery options page "<iaId>"
	When  click on view delivery options presented to other users "<xPathDO>"
	And click on More ways to view this record
	And check the "<xPath>" onsite or offsite "<message>"
	Then click on the "<button>"
	And check the basket has one item

	Examples:
		| iaId     | xPath                                     | message                      | button        | title | xPathDO                                       |
		| C7351413 | (//div[@class='order-option-wrapper'])[2] | Ordering and viewing options | Add to basket |       | //div[@id='staffViewOfOtherUserDOsWrapper']/a |
		| C198022  | (//div[@class='order-option-wrapper'])[2] | Download size approximately  | Add to basket |       | //div[@id='staffViewOfOtherUserDOsWrapper']/a |

Scenario Outline: DigitizedDiscoveryMoreWaysToViewThisRecord
	Given I am on delivery options page "<iaId>"
	When  click on view delivery options presented to other users "<xPathDO>"
	And click on More ways to view this record
	And I should see Available to view free at TNA
	Then Hide More ways to view this record
	And I shouldn't see Available to view free at TNA

	Examples:
		| iaId     | xPathDO                                       |
		| C7351413 | //div[@id='staffViewOfOtherUserDOsWrapper']/a |
		| C198022  | //div[@id='staffViewOfOtherUserDOsWrapper']/a |

Scenario Outline: DigitizedLia
	Given  I am on delivery options page "<iaId>"
	When check the "<message>" for staffin "<xPath>"
	Then click on the "<button>"
	And check for the page "<title>"

	Examples:
		| iaId     | message                                            | xPath                                     | button                | title                 |
		| C2490774 | This is available to download from The Genealogist | (//div[@class='order-option-wrapper'])[1] | The Genealogist       | The National Archives |
		| C2490774 |                                                    |                                           | Visit The Genealogist | The National Archives |
		| C2490774 | This is available to download from The Genealogist | (//div[@class='order-option-wrapper'])[2] |                       |                       |

Scenario Outline: DigitizedLiaMoreWaysToViewThisRecord
	Given I am on delivery options page "<iaId>"
	When  click on view delivery options presented to other users "<xPathDO>"
	And click on More ways to view this record
	Then click on the "<button>"
	And check for the page "<title>"

	Examples:
		| iaId     | button                                          | title                 | xPathDO                                             |
		| C2490774 | Ancestry                                        | The National Archives | (//a[@class='discoveryPrimaryCallToActionLink'])[3] |
		| C2490774 | BMD Registers                                   | The National Archives | (//a[@class='discoveryPrimaryCallToActionLink'])[3] |
		| C2490774 | Available to view free at The National Archives | The National Archives | (//a[@class='discoveryPrimaryCallToActionLink'])[3] |
		| C2490774 | Ancestry[2]                                     | The National Archives | (//a[@class='discoveryPrimaryCallToActionLink'])[3] |

Scenario Outline: DigitizedLiaMoreWaysToViewThisRecordoffsite
	Given I am on delivery options page "<iaId>"
	When  click on view delivery options presented to other users "<xPathDO>"
	And I click on More ways to view this record for offsite
	And click on "<xpath>" for offsite
	Then check for the page "<title>"

	Examples:
		| iaId     | xpath                                                                   | title                 | xPathDO                                             |
		| C2490774 | (//a[contains(text(),'The Genealogist')])[3]                            | The National Archives | (//a[@class='discoveryPrimaryCallToActionLink'])[3] |
		| C2490774 | (//a[contains(text(),'Visit The Genealogist')])[2]                      | The National Archives | (//a[@class='discoveryPrimaryCallToActionLink'])[3] |
		| C2490774 | (//a[contains(text(),'Ancestry')])[2]                                   | The National Archives | (//a[@class='discoveryPrimaryCallToActionLink'])[3] |
		| C2490774 | (//a[contains(text(),'BMD Registers')])[2]                              | The National Archives | (//a[@class='discoveryPrimaryCallToActionLink'])[3] |
		| C2490774 | //a[contains(text(),'Available to view free at The National Archives')] | The National Archives | (//a[@class='discoveryPrimaryCallToActionLink'])[3] |

Scenario Outline: DigitizedOther
	Given I am on delivery options page "<iaId>"
	When  click on view delivery options presented to other users "<xPathDO>"
	Then click on the "<button>"
	And check for the page "<title>"

	Examples:
		| iaId     | xPathDO                                       | button     | title                 |
		| C1847980 | //div[@id='staffViewOfOtherUserDOsWrapper']/a | Findmypast | The National Archives |

Scenario Outline:DigitizedOtherOffsite
	Given I am on delivery options page "<iaId>"
	When  click on view delivery options presented to other users "<xPathDO>"
	And I click on More ways to view this record for offsite
	And click on "<xpath>" for offsite
	Then check for the page "<title>"

	Examples:
		| iaId     | xPathDO                                       | xpath                                                                   | title                 |
		| C1847980 | //div[@id='staffViewOfOtherUserDOsWrapper']/a | (//a[contains(text(),'Findmypast')])[2]                                 | The National Archives |
		| C1847980 | //div[@id='staffViewOfOtherUserDOsWrapper']/a | //a[contains(text(),'Available to view free at The National Archives')] | The National Archives |

Scenario Outline: DisplayAtMuseum
	Given  I am on delivery options page "<iaId>"
	When  click on view delivery options presented to other users "<xPathDO>"
	When check the "<message>" for staffin "<xPath>"
	Then click on the "<button>"
	And check for the page "<title>"

	Examples:
		| iaId    | message                                                                 | xPath                                     | button               | title                 | xPathDO                                             |
		| C393557 | Contact us to find out if you can view a copy at The National Archives. | (//div[@class='order-option-wrapper'])[1] | the Keepers’ Gallery | The National Archives | (//a[@class='discoveryPrimaryCallToActionLink'])[2] |
		| C393557 | Contact us to find out if you can view a copy at The National Archives. | (//div[@class='order-option-wrapper'])[1] | Contact us           | The National Archives | (//a[@class='discoveryPrimaryCallToActionLink'])[2] |
		| C393557 | Ask a member of staff if you can view a copy of this record             | (//div[@class='order-option-wrapper'])[2] |                      |                       | (//a[@class='discoveryPrimaryCallToActionLink'])[2] |

Scenario Outline:DisplayAtMuseumOffSite
	Given I am on delivery options page "<iaId>"
	When  click on view delivery options presented to other users "<xPathDO>"
	And click on "<xpath>" for offsite
	Then check for the page "<title>"

	Examples:
		| iaId    | xPathDO                                             | xpath                                             | title                 |
		| C393557 | (//a[@class='discoveryPrimaryCallToActionLink'])[2] | (//a[contains(text(),'Contact us')])[3]           | The National Archives |
		| C393557 | (//a[@class='discoveryPrimaryCallToActionLink'])[2] | (//a[contains(text(),'the Keepers’ Gallery')])[2] | The National Archives |

Scenario Outline: FileAuthority
	Given I am on delivery options page for fileAuthority "<iaId>"
	When click on view details of this record creator
	Then check for the page "<title>"

	Examples:
		| iaId    | title                 |
		| F133246 | The National Archives |

Scenario Outline: GovtWebArchive
	Given  I am on delivery options page "<iaId>"
	When check the "<message>" for staffin "<xPath>"
	Then check for the page "<title>"

	Examples:
		| iaId   | message                                                                                | xPath                                  | title                 |
		| C16665 | This record is held by the UK Government Web Archive                                   | (//div[@class='order-option-wrapper']) | The National Archives |
		| C16665 | Find a link in the catalogue description to the archived website that holds the record | (//div[@class='order-option-wrapper']) | The National Archives |

Scenario Outline: invigilationSafeRoom
	Given  I am on delivery options page "<iaId>"
	When  click on view delivery options presented to other users "<xPathDO>"
	And check the "<message>" for staffin "<xPath>"
	Then click on the "<button>"
	And check for the page "<title>"

	Examples:
		| iaId     | xPathDO                                                                | xPath                                     | message                                                                 | button           | title                 |
		| C4771662 | //a[contains(text(),'View delivery options presented to other users')] | (//div[@class='order-option-wrapper'])[1] | You can view this record under supervision in our Invigilation Room     |                  |                       |
		| C4780207 | //a[contains(text(),'View delivery options presented to other users')] | (//div[@class='order-option-wrapper'])[1] | Your order will take approximately 45 minutes to be prepared            |                  |                       |
		| C4771662 | //a[contains(text(),'View delivery options presented to other users')] | (//div[@class='order-option-wrapper'])[2] | You can view this record under supervision in our Invigilation Room     |                  |                       |
		| C4780207 | //a[contains(text(),'View delivery options presented to other users')] | (//div[@class='order-option-wrapper'])[2] | You must have a reader's ticket to order this record                    | reader's ticket  | The National Archives |
		| C4771662 | //a[contains(text(),'View delivery options presented to other users')] | (//div[@class='order-option-wrapper'])[3] | This record can only be seen under supervision at The National Archives | Copy this record | The National Archives |
		| C4780207 | //a[contains(text(),'View delivery options presented to other users')] | (//div[@class='order-option-wrapper'])[3] | You must have a reader's ticket to view this record                     | Order in advance | The National Archives |

Scenario Outline: InUse
	Given  I am on delivery options page "<iaId>"
	When  click on view delivery options presented to other users "<xPathDO>"
	And check the "<message>" for staffin "<xPath>"
	Then click on the "<button>"
	And check for the page "<title>"

	Examples:
		| iaId     | xPath                                     | message                                                                 | xPathDO                                       | button                   | title                 |
		| C4771085 | (//div[@class='order-option-wrapper'])[1] | This record is currently in use                                         | //div[@id='staffViewOfOtherUserDOsWrapper']/a | order records in advance | The National Archives |
		| C4771085 | (//div[@class='order-option-wrapper'])[1] | Talk to a member of staff to find out when it may be free               | //div[@id='staffViewOfOtherUserDOsWrapper']/a | visit Kew                | The National Archives |
		| C4771085 | (//div[@class='order-option-wrapper'])[2] | This record has not been digitised and cannot be downloaded             | //div[@id='staffViewOfOtherUserDOsWrapper']/a | reader's ticket          | The National Archives |
		| C4771085 | (//div[@class='order-option-wrapper'])[2] | You can order records in advance to be ready for you when you visit Kew | //div[@id='staffViewOfOtherUserDOsWrapper']/a | Order in advance         | The National Archives |
		| C4771085 | (//div[@class='order-option-wrapper'])[2] | Or, you can request a quotation for a copy to be sent to you.           | //div[@id='staffViewOfOtherUserDOsWrapper']/a | Request a copy           | Page Check Request    |

Scenario Outline: LocalArchive
	Given  I am on delivery options page "<iaId>"
	When check the "<message>" for staffin "<xPath>"
	Then click on the "<button>"
	And check for the page "<title>"

	Examples:
		| iaId      | xPath                                  | message                                                                        | button              | title                 |
		| C1699211  | (//div[@class='order-option-wrapper']) | This record is held by National Maritime Museum: The Caird Library and Archive | See contact details | The National Archives |
		| C14520556 | (//div[@class='order-option-wrapper']) | This record is held by National Maritime Museum: The Caird Library and Archive | See contact details | The National Archives |

Scenario Outline: MissingLost
	Given  I am on delivery options page "<iaId>"
	When check the "<message>" for staffin "<xPath>"
	Then  check for the page "<title>"

	Examples:
		| iaId     | xPath                                  | message                                                          | title                 |
		| C2547266 | (//div[@class='order-option-wrapper']) | This record is missing and is unavailable                        | The National Archives |
		| C2547266 | (//div[@class='order-option-wrapper']) | Additional information may be found in the catalogue description | The National Archives |

Scenario Outline: MouldTreatment
	Given  I am on delivery options page "<iaId>"
	When  click on view delivery options presented to other users "<xPathDO>"
	When check the "<message>" for staffin "<xPath>"
	Then click on the "<button>"
	And check for the page "<title>"

	Examples:
		| iaId     | xPathDO                                             | xPath                                     | message                                                                  | button     | title      |
		| C4364677 | (//a[@class='discoveryPrimaryCallToActionLink'])[2] | (//div[@class='order-option-wrapper'])[1] | Please contact a member of staff to request a specialist assessment.     |            |            |
		| C4364677 | (//a[@class='discoveryPrimaryCallToActionLink'])[2] | (//div[@class='order-option-wrapper'])[2] | This record requires treatment for mould                                 |            |            |
		| C4364677 | (//a[@class='discoveryPrimaryCallToActionLink'])[2] | (//div[@class='order-option-wrapper'])[3] | This record requires treatment for mould                                 | contact    | Contact us |
		| C4364677 | (//a[@class='discoveryPrimaryCallToActionLink'])[2] | (//div[@class='order-option-wrapper'])[3] | Please contact The National Archives to request a specialist assessment. | Contact us | Contact us |

Scenario Outline: offSite
	Given  I am on delivery options page "<iaId>"
	When  click on view delivery options presented to other users "<xPathDO>"
	When check the "<message>" for staffin "<xPath>"
	Then click on the "<button>"
	And check for the page "<title>"

	Examples:
		| iaId     | xPathDO                                             | xPath                                     | message                                                                                                                                                             | button                   | title                      |
		| C2698319 | (//a[@class='discoveryPrimaryCallToActionLink'])[5] | (//div[@class='order-option-wrapper'])[1] | You may place an advanced order request to see this record at The National Archives. It will take three working days to bring this record to The National Archives. |                          |                            |
		| C2698319 | (//a[@class='discoveryPrimaryCallToActionLink'])[5] | (//div[@class='order-option-wrapper'])[2] | You may place an advanced order request to see this record at The National Archives. It will take three working days to bring this record to The National Archives. | Advanced order           | Order documents in advance |
		| C2698319 | (//a[@class='discoveryPrimaryCallToActionLink'])[5] | (//div[@class='order-option-wrapper'])[3] | This record has not been digitised and cannot be downloaded                                                                                                         | order records in advance | The National Archives      |
		| C2698319 | (//a[@class='discoveryPrimaryCallToActionLink'])[5] | (//div[@class='order-option-wrapper'])[3] | This record is stored off site and will take three working days to be delivered to The National Archives.                                                           | visit Kew                | Visit us                   |
		| C2698319 | (//a[@class='discoveryPrimaryCallToActionLink'])[5] | (//div[@class='order-option-wrapper'])[3] | You can order records in advance to be ready for you when you visit Kew.                                                                                            | reader's ticket          | The National Archives      |
		| C2698319 | (//a[@class='discoveryPrimaryCallToActionLink'])[5] | (//div[@class='order-option-wrapper'])[3] | Or, you can request a quotation for a copy to be sent to you.                                                                                                       | Order in advance         | The National Archives      |
		| C2698319 | (//a[@class='discoveryPrimaryCallToActionLink'])[5] | (//div[@class='order-option-wrapper'])[3] | Please order before 11:00 three working days in advance of your visit.                                                                                              | Order a copy             | Page Check Request         |

Scenario Outline: PaidSearch
	Given  I am on delivery options page "<iaId>"
	When  click on view delivery options presented to other users "<xPathDO>"
	When check the "<message>" for staffin "<xPath>"
	Then click on the "<button>"
	And check for the page "<title>"

	Examples:
		| iaId                             | xPathDO                                             | xPath                                     | message                                                                                                                  | button                             | title                              |
		| 90ad00a1aa6149efa3991fab6037a5ec | (//a[@class='discoveryPrimaryCallToActionLink'])[2] | (//div[@class='order-option-wrapper'])[1] | To request a search of closed records you are required to upload documents as proof that the person is no longer living. | Request a search of closed records | Request a search of closed records |

Scenario Outline: Surrogate
	Given  I am on delivery options page "<iaId>"
	When  click on view delivery options presented to other users "<xPathDO>"
	And check the "<message>" for staffin "<xPath>"
	Then click on the "<button>"
	And check for the page "<title>"

	Examples:
		| iaId     | xPathDO                                             | xPath                                     | message                                                      | button          | title                 |
		| C2050263 | (//a[@class='discoveryPrimaryCallToActionLink'])[2] | (//div[@class='order-option-wrapper'])[1] | Ask a member of staff if you need help finding this record.  |                 |                       |
		| C9188919 | (//a[@class='discoveryPrimaryCallToActionLink'])[2] | (//div[@class='order-option-wrapper'])[2] | Ask a member of staff if you need help finding this record.  | reader's ticket | The National Archives |
		| C3000330 | (//a[@class='discoveryPrimaryCallToActionLink'])[2] | (//div[@class='order-option-wrapper'])[3] | This record has not been digitised and cannot be downloaded. | Order a copy    | Page Check Request    |

Scenario Outline: TooLargeToCopyOriginal
	Given  I am on delivery options page "<iaId>"
	When  click on view delivery options presented to other users "<xPathDO>"
	And check the "<message>" for staffin "<xPath>"
	Then click on the "<button>"
	And check for the page "<title>"

	Examples:
		| iaId     | xPathDO                                             | xPath                                     | message                                                                                                                                     | button          | title                 |
		| C4560825 | (//a[@class='discoveryPrimaryCallToActionLink'])[4] | (//div[@class='order-option-wrapper'])[1] | Your order will take approximately 45 minutes to be prepared.                                                                               |                 |                       |
		| C4560825 | (//a[@class='discoveryPrimaryCallToActionLink'])[4] | (//div[@class='order-option-wrapper'])[2] | This document is either too large or of a condition or media type that means that our record copying services are unable to provide a copy. | reader's ticket | The National Archives |
		| C4560825 | (//a[@class='discoveryPrimaryCallToActionLink'])[4] | (//div[@class='order-option-wrapper'])[2] | This record is available to order and view                                                                                                  | Image Library   | The National Archives |

Scenario Outline: TooLargeToCopyOriginalOffSite
	Given  I am on delivery options page "<iaId>"
	When  click on view delivery options presented to other users "<xPathDO>"
	And scroll down
	And check the "<message>" for staffin "<xPath>"
	Then click on the "<button>"
	And check for the page "<title>"

	Examples:
		| iaId     | xPathDO                                             | xPath                                     | message                                                                                                                                     | button                   | title                 |
		| C4560825 | (//a[@class='discoveryPrimaryCallToActionLink'])[4] | (//div[@class='order-option-wrapper'])[3] | This document is either too large or of a condition or media type that means that our record copying services are unable to provide a copy. | order records in advance | The National Archives |
		| C4560825 | (//a[@class='discoveryPrimaryCallToActionLink'])[4] | (//div[@class='order-option-wrapper'])[3] | Our Image Library may be able to provide you with a specialist quote.                                                                       | visit Kew                | Visit us              |
		| C4560825 | (//a[@class='discoveryPrimaryCallToActionLink'])[4] | (//div[@class='order-option-wrapper'])[3] | You can order records in advance to be ready for you when you visit Kew                                                                     | Order in advance         | The National Archives |

Scenario Outline: TooLargeToCopySurrogate
	Given  I am on delivery options page "<iaId>"
	When  click on view delivery options presented to other users "<xPathDO>"
	And check the "<message>" for staffin "<xPath>"
	Then click on the "<button>"
	And check for the page "<title>"

	Examples:
		| iaId     | xPathDO                                             | xPath                                     | message                                                      | button          | title                 |
		| C6934963 | (//a[@class='discoveryPrimaryCallToActionLink'])[1] | (//div[@class='order-option-wrapper'])[1] | Ask a member of staff if you need help finding this record.  |                 |                       |
		| C6934963 | (//a[@class='discoveryPrimaryCallToActionLink'])[1] | (//div[@class='order-option-wrapper'])[2] | Ask a member of staff if you need help finding this record.  | reader's ticket | The National Archives |
		| C6934963 | (//a[@class='discoveryPrimaryCallToActionLink'])[1] | (//div[@class='order-option-wrapper'])[3] | This record has not been digitised and cannot be downloaded. | Order a copy    | Page Check Request    |
		| C8135237 | (//a[@class='discoveryPrimaryCallToActionLink'])[1] | (//div[@class='order-option-wrapper'])[1] | Ask a member of staff if you need help finding this record.  |                 |                       |
		| C8135237 | (//a[@class='discoveryPrimaryCallToActionLink'])[1] | (//div[@class='order-option-wrapper'])[2] | Ask a member of staff if you need help finding this record.  | reader's ticket | The National Archives |
		| C8135237 | (//a[@class='discoveryPrimaryCallToActionLink'])[1] | (//div[@class='order-option-wrapper'])[3] | This record has not been digitised and cannot be downloaded. | Order a copy    | Page Check Request    |
		| C8135239 | (//a[@class='discoveryPrimaryCallToActionLink'])[1] | (//div[@class='order-option-wrapper'])[1] | Ask a member of staff if you need help finding this record.  |                 |                       |
		| C8135239 | (//a[@class='discoveryPrimaryCallToActionLink'])[1] | (//div[@class='order-option-wrapper'])[2] | Ask a member of staff if you need help finding this record.  | reader's ticket | The National Archives |
		| C8135239 | (//a[@class='discoveryPrimaryCallToActionLink'])[1] | (//div[@class='order-option-wrapper'])[3] | This record has not been digitised and cannot be downloaded. | Order a copy    | Page Check Request    |

Scenario Outline: UnAvailable
	Given  I am on delivery options page "<iaId>"
	When check the "<message>" for staffin "<xPath>"
	Then check for the page "<title>"

	Examples:
		| iaId      | message                                                                                                | xPath                                  | title                 |
		| C11692008 | This record is not available to order. More information may be available in the catalogue description. | (//div[@class='order-option-wrapper']) | The National Archives |

Scenario Outline: Unfit
	Given  I am on delivery options page "<iaId>"
	When  click on view delivery options presented to other users "<xPathDO>"
	And check the "<message>" for staffin "<xPath>"
	Then click on the "<button>"
	And check for the page "<title>"

	Examples:
		| iaId    | xPathDO                                             | xPath                                     | message                                                                                                               | button     | title      |
		| C513426 | (//a[@class='discoveryPrimaryCallToActionLink'])[2] | (//div[@class='order-option-wrapper'])[1] | In rare cases, access might not be possible. Please contact a member of staff to request a specialist assessment.     |            |            |
		| C513426 | (//a[@class='discoveryPrimaryCallToActionLink'])[2] | (//div[@class='order-option-wrapper'])[2] | In rare cases, access might not be possible. Please contact a member of staff to request a specialist assessment.     |            |            |
		| C513426 | (//a[@class='discoveryPrimaryCallToActionLink'])[2] | (//div[@class='order-option-wrapper'])[3] | In rare cases, access might not be possible. Please contact The National Archives to request a specialist assessment. | Contact us | Contact us |
		| C513426 | (//a[@class='discoveryPrimaryCallToActionLink'])[2] | (//div[@class='order-option-wrapper'])[3] | In rare cases, access might not be possible. Please contact The National Archives to request a specialist assessment. | contact    | Contact us |