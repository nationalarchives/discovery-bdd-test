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
		| C4771085  |

Scenario Outline: FOI1939 register
	Given I am on Request a search of closed records page
	When I enter the details "<searchFirstName>", "<searchLastName>","<gender>","<dOB>","<dataSubjectAccess>", upload proof of identity
	And I enter contact details "<firstName>","<lastName>","<email>","<confirmEmail>","<address>","<TownCity>","<postcode>","<Country>"
	And Submit request
	Then I can see confirmation page

	Examples:
		| searchFirstName | searchLastName | gender | dOB        | dataSubjectAccess | firstName | lastName  | email                     | confirmEmail              | address         | TownCity | postcode | Country        |
		| ThisIsATest     | George         | Female | 01/01/1900 | notSubject        | Tester    | SurTester | tnadiscovery100@gmail.com | tnadiscovery100@gmail.com | 63highstreet    | London   | tw96nu   | United Kingdom |
		| ThisIsATest     | James          | Male   | 01/11/1890 | isSubject         | Tester    | SurTester | tnadiscovery100@gmail.com | tnadiscovery100@gmail.com | 99 highway road | London   | tw81nn   | United Kingdom |

Scenario Outline: HomeGuard
	Given I am on FOI request page for "<iaId>"
	When I upload evidence of death, enter "<firstName>","<lastName>","<email>","<adress1>","<townCity>","<postcode>","<country>"
	And scroll down add to basket, go to basket, viewbasket,checkout, enter email address under send a reciept
	And T&C, Submit order pay through paypal
	Then I should see Thank you for your order

	Examples:
		| iaId                             | firstName | lastName              | email                     | adress1 | townCity | postcode | country        |
		| 90ad00a1aa6149efa3991fab6037a5ec | test      | testing for something | tnadiscovery100@gmail.com | 99      | coventry | cv25hz   | United Kingdom |
		| c5c872216727433d95c427b801b9a9ba | test      | testing for something | tnadiscovery100@gmail.com | 65      | london   | tw96aw   | United Kingdom |
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

Scenario Outline: FOIRequest_WO416
	Given I am on eCommerce page for to upload death certificate "<iaId>"
	When click on request a search of closed records, enter search details "<searchFirstName>","<searchLastName>","<dOB>","<category>"
	And I upload evidence of death, enter "<firstName>","<lastName>","<email>","<adress1>","<townCity>","<postcode>","<country>"
	And scroll down add to basket, go to basket, viewbasket,checkout, enter email address under send a reciept
	And T&C, Submit order pay through paypal
	Then I should see Thank you for your order
	And sign in now

	Examples:
		| iaId                             | searchFirstName | searchLastName | dOB        | category        | firstName | lastName  | email                     | adress1 | townCity | postcode | country        |
		#| C14568023                        | Test            | George         | 10/11/1888 | Army            | Tester    | SurTester | tnadiscovery100@gmail.com | 99      | coventry | cv25hz   | United Kingdom |
		| 90ad00a1aa6149efa3991fab6037a5ec | Test            | David          | 05/03/1770 | Royal Navy      | test      | tester    | tnadiscovery100@gmail.com | 65      | london   | tw96aw   | United Kingdom |
		| 90ad00a1aa6149efa3991fab6037a5ec | Test            | David          | 05/03/1770 | Royal Air Force | test      | tester    | tnadiscovery100@gmail.com | 65      | Reading  | tw96aw   | Afghanistan    |