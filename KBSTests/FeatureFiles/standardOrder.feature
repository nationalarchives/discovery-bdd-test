Feature: standardOrder

Background:
	Given Go to KBS page for standard order
	When click on Select a date under book a standard order visit
	And click on date in the first row for standard order
	# test reader tickets
	# 9503041  9499014  9499007  9487253  9487246  9487239  9487215  9487208  9487198  9487181  9487174   9487167  9487150  9338003  
	# 9497937  9497920  9497906  9497913  9497896  9497872  9497889  9497865  9497858  9497841   9086544  9374036 9374005

Scenario Outline: standardOrder_orderDocNow
	When enter "<readerTicketNo>","<firstName>","<lastName>","<email>","<telNo>" and complete booking for standard order
	Then check the page title, click on Order documents now for standard order
	And enter two document references "<DocRef1>","<DocRef2>", enter "<ReserveDocRef1>"

	Examples:
		| readerTicketNo | firstName   | lastName   | email                     | telNo | DocRef1     | DocRef2     | ReserveDocRef1 |
		| 9487174        | firstTester | lastTester | tnadiscovery100@gmail.com | abcd  | CAB 132/172 | SC 2/200/57 | ED 24/1123     |

Scenario Outline: standardOrder_orderDocLater
	When enter "<readerTicketNo>","<firstName>","<lastName>","<email>","<telNo>" and complete booking for standard order
	Then check the page title, click on Order documents later for standard order
	Examples:
		| readerTicketNo | firstName   | lastName   | email                     | telNo |
		| 9487181        | firstTester | lastTester | tnadiscovery100@gmail.com | abcd  |

Scenario: standardOrder_cancelVisit
When enter "<readerTicketNo>","<firstName>","<lastName>","<email>","<telNo>" and complete booking for standard order
	Then check the page title, click on Order documents now for standard order
	And click on cancel your visit, check the page title and proceed for standard order
	And I can see the message Your visit has been cancelled
	Examples:
		| readerTicketNo | firstName   | lastName   | email                     | telNo |
		| 9487208        | firstTester | lastTester | tnadiscovery100@gmail.com | abcd  |
