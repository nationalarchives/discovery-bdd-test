Feature: bulkOrder

Background:
	Given Go to KBS page
	When click on Select a date under book a bulk order visit
	And click on date in the first row

# test reader tickets
# 9503041  9499014  9499007  9487253  9487246  9487239  9487215  9487208  9487198  9487181  9487174   9487167  9487150  9338003
# 9497937  9497920  9497906  9497913  9497896  9497872  9497889  9497865  9497858  9497841  9086544   9374036  9338003  9374005
Scenario Outline: bulkOrder_orderDocNow_20
	When enter "<readerTicketNo>","<firstName>","<lastName>","<email>","<telNo>" and complete booking
	Then check the page title, click on Order documents now
	And enter "<series>","<DocRef1>","<DocRef2>","<DocRef3>","<DocRef4>","<DocRef5>","<DocRef6>","<DocRef7>","<DocRef8>","<DocRef9>","<DocRef10>"
	And enter all the doc reference numbers "<DocRef11>","<DocRef12>","<DocRef13>","<DocRef14>","<DocRef15>","<DocRef16>","<DocRef17>","<DocRef18>","<DocRef19>","<DocRef20>"
	And check the page title order summary

	Examples:
		| readerTicketNo | firstName   | lastName   | email                     | telNo | series  | DocRef1   | DocRef2   | DocRef3   | DocRef4   | DocRef5   | DocRef6   | DocRef7   | DocRef8   | DocRef9   | DocRef10   | DocRef11   | DocRef12   | DocRef13   | DocRef14   | DocRef15   | DocRef16   | DocRef17   | DocRef18   | DocRef19   | DocRef20   |
		| 3656217        | firstTester | lastTester | tnadiscovery100@gmail.com | abcd  | CAB 120 | CAB 120/1 | CAB 120/2 | CAB 120/3 | CAB 120/4 | CAB 120/5 | CAB 120/6 | CAB 120/7 | CAB 120/8 | CAB 120/9 | CAB 120/10 | CAB 120/11 | CAB 120/12 | CAB 120/13 | CAB 120/14 | CAB 120/15 | CAB 120/16 | CAB 120/17 | CAB 120/18 | CAB 120/19 | CAB 120/20 |

Scenario Outline: bulkOrder_orderDocLater
	When enter "<readerTicketNo>","<firstName>","<lastName>","<email>","<telNo>" and complete booking
	Then check the page title, click on Order documents later
	And check the page title, click on Yes, I’d like to order my documents later

	Examples:
		| readerTicketNo | firstName | lastName   | email                     | telNo |
		| 9497920        | Tester    | lastTester | tnadiscovery100@gmail.com | abcd  |

Scenario Outline: bulkOrder_orderDocLater_No
	When enter "<readerTicketNo>","<firstName>","<lastName>","<email>","<telNo>" and complete booking
	Then check the page title, click on Order documents later
	And check the page title, click on No, I’d like to order my documents now
    And enter "<series>","<DocRef1>","<DocRef2>","<DocRef3>","<DocRef4>","<DocRef5>","<DocRef6>","<DocRef7>","<DocRef8>","<DocRef9>","<DocRef10>"
	And enter all the doc reference numbers "<DocRef11>","<DocRef12>","<DocRef13>","<DocRef14>","<DocRef15>","<DocRef16>","<DocRef17>","<DocRef18>","<DocRef19>","<DocRef20>"
		And check the page title order summary

	Examples:
		| readerTicketNo | firstName   | lastName   | email                     | telNo | series  | DocRef1   | DocRef2   | DocRef3   | DocRef4   | DocRef5   | DocRef6   | DocRef7   | DocRef8   | DocRef9   | DocRef10   | DocRef11   | DocRef12   | DocRef13   | DocRef14   | DocRef15   | DocRef16   | DocRef17   | DocRef18   | DocRef19   | DocRef20   |
		| 9503041        | firstTester | lastTester | tnadiscovery100@gmail.com | abcd  | CAB 120 | CAB 120/1 | CAB 120/2 | CAB 120/3 | CAB 120/4 | CAB 120/5 | CAB 120/6 | CAB 120/7 | CAB 120/8 | CAB 120/9 | CAB 120/10 | CAB 120/11 | CAB 120/12 | CAB 120/13 | CAB 120/14 | CAB 120/15 | CAB 120/16 | CAB 120/17 | CAB 120/18 | CAB 120/19 | CAB 120/20 |

Scenario: bulkOrder_cancelVisit
	When enter "<readerTicketNo>","<firstName>","<lastName>","<email>","<telNo>" and complete booking

	Then check the page title, click on Order documents now
	And click on cancel your visit, check the page title and proceed
	And I can see the message Your visit has been cancelled on the top of the page
		Examples:
		| readerTicketNo | firstName | lastName   | email                     | telNo |
		| 9487253        | Tester    | lastTester | tnadiscovery100@gmail.com | abcd  |