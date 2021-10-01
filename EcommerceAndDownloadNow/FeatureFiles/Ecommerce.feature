Feature: Ecommerce

Scenario Outline: certifiedNaturalisationRequest
	Given I am on eCommerce page for "<iaId>"
	And Request a copy, add to basket, checkout and signed in
	When click on proceed, T&C, pay through paypal
	Then I should see Thank you for your order

	Examples:
		| iaId      |
		| C16120922 |
		| C11865373 |

Scenario Outline: DigitizedAddToBasket
	Given I am on eCommerce page for "<iaId>"
	When add to basket, go to basket, viewbasket,checkout, enter email address under send a reciept
	And T&C, Submit order pay through paypal
	Then I should see Thank you for your order

	Examples:
		| iaId     |
		| C7351413 |

Scenario Outline: YourOrders_RequestAcopy
	Given I am on eCommerce page for "<iaId>"
	And Request a copy, add to basket, checkout and signed in
	When click on proceed, T&C, pay through paypal
	Then go to your orders and I can see order number from your orders list

	Examples:
		| iaId      |
		| C16120922 |
		| C11865373 |

#| C4771085  |
Scenario Outline: 1939 register SAR
	Given I am on Request a search of closed records page
	When I enter the details "<searchFirstName>", "<searchLastName>","<gender>","<dOB>","<dataSubjectAccess>", upload proof of identity
	And I enter contact details "<firstName>","<lastName>","<email>","<confirmEmail>","<address>","<TownCity>","<postcode>","<Country>"
	And Submit request
	Then I can see confirmation page

	Examples:
		| searchFirstName | searchLastName | gender | dOB        | dataSubjectAccess | firstName | lastName  | email                     | confirmEmail              | address         | TownCity | postcode | Country        |
		| ThisIsATest     | George         | Female | 01/01/1900 | notSubject        | Tester    | SurTester | tnadiscovery100@gmail.com | tnadiscovery100@gmail.com | 63highstreet    | London   | tw96nu   | United Kingdom |
		| ThisIsATest     | James          | Male   | 01/11/1890 | isSubject         | Tester    | SurTester | tnadiscovery100@gmail.com | tnadiscovery100@gmail.com | 99 highway road | London   | tw81nn   | United Kingdom |

Scenario Outline: 1939 Register FOI
	Given I am on Request a search of closed records for register FOI page
	When I enter the details "<searchFirstName>", "<searchLastName>","<gender>","<dOB>",doesn't have dataSubjectAccess, upload proof of identity
	And I enter contact details "<firstName>","<lastName>","<email>","<confirmEmail>","<address>","<TownCity>","<postcode>","<Country>"
	And scroll down add to basket, go to basket, viewbasket,checkout, enter email address under send a reciept
	And T&C, Submit order pay through paypal
	Then I should see Thank you for your order

	Examples:
		| searchFirstName | searchLastName | gender | dOB        | firstName | lastName  | email                     | confirmEmail              | address         | TownCity | postcode | Country        |
		| ThisIsATest     | George         | Female | 01/01/1900 | Tester    | SurTester | tnadiscovery100@gmail.com | tnadiscovery100@gmail.com | 63highstreet    | London   | tw96nu   | United Kingdom |
		| ThisIsATest     | James          | Male   | 01/11/1890 | Tester    | SurTester | tnadiscovery100@gmail.com | tnadiscovery100@gmail.com | 99 highway road | London   | tw81nn   | United Kingdom |

Scenario Outline: HomeGuard
	Given I am on FOI request page for "<iaId>"
	When I upload evidence of death, enter "<firstName>","<lastName>","<email>","<adress1>","<townCity>","<postcode>","<country>"
	And scroll down add to basket, go to basket, viewbasket,checkout, enter email address under send a reciept
	And T&C, Submit order pay through paypal
	Then I should see Thank you for your order

	Examples:
		| iaId                             | firstName | lastName              | email                     | adress1 | townCity | postcode | country        |
		| 90ad00a1aa6149efa3991fab6037a5ec | test      | testing for something | tnadiscovery100@gmail.com | 99      | coventry | cv25hz   | United Kingdom |
		| 311fb42eed1c4ceb81914f014fe98a91 | test      | testing for something | tnadiscovery100@gmail.com | 65      | london   | tw96aw   | United Kingdom |

#| 9f6e3f6c40ce4cdd9707728b7348c84d | test      | testing for something | tnadiscovery100@gmail.com | 789     | reading  | rg16jr   | United Kingdom |
Scenario Outline: PageCheckRequestACopy
	Given I am on page check page for "<iaId>"
	#Then I should see the coronavirus update page
	When click on Get started, enter details, add to basket, checkout, signed in
	And T&C, Submit order pay through paypal
	Then I should see Thank you for your order

	Examples:
		| iaId     |
		| C6553048 |
		| C4771085 |

Scenario Outline: PageCheckRequestACopy_Morethan1000Characters
This scenario we are checking the validation message by entering morethan 1000 charcters in customer instructions field.
	Given I am on page check page for "<iaId>"
	#Then I should see the coronavirus update page
	When click on Get started, enter morethan one thousand characters
	Then I can see a message Customer Instructions cannot exceed one thousand characters

	Examples:
		| iaId     |
		| C2050263 |
		| C2849839 |

Scenario Outline: HG FOI Items
	Given I am on eCommerce page for to upload death certificate "<iaId>"
	When click on request a search of closed records, enter search details "<searchFirstName>","<searchLastName>","<dOB>","<category>"
	And I upload evidence of death, enter "<firstName>","<lastName>","<email>","<adress1>","<townCity>","<postcode>","<country>"
	And scroll down add to basket, go to basket, viewbasket,checkout, enter email address under send a reciept
	And T&C, Submit order pay through paypal
	Then I should see Thank you for your order
	And sign in now

	Examples:
		| iaId                             | searchFirstName | searchLastName | dOB        | category        | firstName | lastName | email                     | adress1 | townCity | postcode | country        |
		| 90ad00a1aa6149efa3991fab6037a5ec | Test            | David          | 05/03/1770 | Royal Navy      | test      | tester   | tnadiscovery100@gmail.com | 65      | london   | tw96aw   | United Kingdom |
		| 90ad00a1aa6149efa3991fab6037a5ec | Test            | David          | 05/03/1770 | Royal Air Force | test      | tester   | tnadiscovery100@gmail.com | 65      | Reading  | tw96aw   | Afghanistan    |

Scenario Outline: PoWItemsFOI
	Given I am on FOI request page for "<iaId>"
	When I enter the following details "<searchFirstName>", "<searchLastName>","<dOB>" upload proof of identity
	And I upload evidence of death, enter "<firstName>","<lastName>","<email>","<adress1>","<townCity>","<postcode>","<country>"
	And Submit request
	Then I can see confirmation page

	Examples:
		| iaId      | searchFirstName | searchLastName | dOB        | firstName | lastName              | email                     | adress1 | townCity | postcode | country        |
		| C16953969 | Tester          | William        | 05/09/1680 | test      | testing for something | tnadiscovery100@gmail.com | 65      | london   | tw96aw   | United Kingdom |

Scenario Outline: PoWPiecesFOI
	Given I am on FOI request page for "<iaId>"
	When I enter the following details "<searchFirstName>", "<searchLastName>","<dOB>" upload proof of identity
	And I upload evidence of death, enter "<firstName>","<lastName>","<email>","<adress1>","<townCity>","<postcode>","<country>"
	And scroll down add to basket, go to basket, viewbasket,checkout, enter email address under send a reciept
	And T&C, Submit order pay through paypal
	Then I should see Thank you for your order
	And sign in now

	Examples:
		| iaId      | searchFirstName | searchLastName | dOB        | firstName | lastName              | email                     | adress1 | townCity | postcode | country        |
		| C14568159 | Tester          | David          | 05/03/1770 | test      | testing for something | tnadiscovery100@gmail.com | 99      | coventry | cv25hz   | United Kingdom |

Scenario Outline: PoWPiecesSAR
	Given I am on PoWSAR page for "<iaId>"
	When I enter the details "<searchFirstName>", "<searchLastName>" ,"<dOB>","<dataSubjectAccess>",no gender, upload proof of identity
	And I enter contact details "<firstName>","<lastName>","<email>","<confirmEmail>","<address>","<TownCity>","<postcode>","<Country>"
	And confirm Submit request
	Then I can see confirmation page

	Examples:
		| iaId                             | searchFirstName | searchLastName | dOB        | dataSubjectAccess | firstName | lastName  | email                     | confirmEmail              | address         | TownCity | postcode | Country        |
		| C14568159                        | ThisIsATest     | George         | 01/01/1900 | notSubject        | Tester    | SurTester | tnadiscovery100@gmail.com | tnadiscovery100@gmail.com | 63highstreet    | London   | tw96nu   | United Kingdom |
		| C14568159                        | ThisIsATest     | James          | 01/11/1890 | isSubject         | Tester    | SurTester | tnadiscovery100@gmail.com | tnadiscovery100@gmail.com | 99 highway road | London   | tw81nn   | United Kingdom |
		| 90ad00a1aa6149efa3991fab6037a5ec | ThisIsATest     | George         | 01/01/1900 | notSubject        | Tester    | SurTester | tnadiscovery100@gmail.com | tnadiscovery100@gmail.com | 63highstreet    | London   | tw96nu   | United Kingdom |
		| 90ad00a1aa6149efa3991fab6037a5ec | ThisIsATest     | James          | 01/11/1890 | isSubject         | Tester    | SurTester | tnadiscovery100@gmail.com | tnadiscovery100@gmail.com | 99 highway road | London   | tw81nn   | United Kingdom |

Scenario Outline:  PoWItemsSAR
	Given I am on PoWSAR page for "<iaId>"
	When I enter the details "<searchFirstName>", "<searchLastName>" ,"<dOB>","<dataSubjectAccess>",no gender, upload proof of identity
	And I enter contact details "<firstName>","<lastName>","<email>","<confirmEmail>","<address>","<TownCity>","<postcode>","<Country>"
	And confirm Submit request
	Then I can see confirmation page

	Examples:
		| iaId      | searchFirstName | searchLastName | dOB        | dataSubjectAccess | firstName | lastName  | email                     | confirmEmail              | address         | TownCity | postcode | Country        |
		| C16953969 | ThisIsATest     | George         | 01/01/1900 | notSubject        | Tester    | SurTester | tnadiscovery100@gmail.com | tnadiscovery100@gmail.com | 63highstreet    | London   | tw96nu   | United Kingdom |
		| C16953969 | ThisIsATest     | James          | 01/11/1890 | isSubject         | Tester    | SurTester | tnadiscovery100@gmail.com | tnadiscovery100@gmail.com | 99 highway road | London   | tw81nn   | United Kingdom |

Scenario Outline: ClosedRecordRequest

 https://test-discovery.nationalarchives.gov.uk/foirequest?reference=WO%20416/178/416

 Given I am on ClosedRecordRequest page for the above ref
 When I enter "<title>", "<firstName>","<lastName>","<email>","<address1>","<address2>","<town>","<county>","<postcode>","<country>","<telephone>","<additionalInfo>"
 Then click on Submit and I should see the confirmation page
 
 Examples: 
 | title | firstName | lastName  | email                     | address1 | address2           | town   | county    | postcode | country        | telephone | additionalInfo |
 | Mr    | Tester    | surTester | tnadiscovery100@gmail.com | 99       | gainsborough grove | London | Middlesex | cv2 5hz  | United Kingdom | 1234567   | This is a test |
