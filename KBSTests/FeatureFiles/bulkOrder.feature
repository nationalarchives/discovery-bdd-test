Feature: bulkOrder

Background:
	Given Go to KBS page
	When click on Select a date under book a bulk order visit
	And click on date in the first row

@mytag
Scenario Outline: bulkOrder_orderDocNow_20
	When enter "<readerTicketNo>","<firstName>","<lastName>","<email>","<telNo>" and complete booking

	Then check the page title, click on Order documents now
	And enter "<series>","<DocRef1>","<DocRef2>","<DocRef3>","<DocRef4>","<DocRef5>","<DocRef6>","<DocRef7>","<DocRef8>","<DocRef9>","<DocRef10>","<DocRef11>","<DocRef12>","<DocRef13>","<DocRef14>","<DocRef15>","<DocRef16>","<DocRef17>","<DocRef18>","<DocRef19>","<DocRef20>"

	Examples:
		| readerTicketNo | firstName   | lastName   | email                     | telNo | series  | DocRef1   | DocRef2   | DocRef3   | DocRef4   | DocRef5   | DocRef6   | DocRef7   | DocRef8   | DocRef9   | DocRef10   | DocRef11   | DocRef12   | DocRef13   | DocRef14   | DocRef15   | DocRef16   | DocRef17   | DocRef18   | DocRef19   | DocRef20   |
		| 9497872        | firstTester | lastTester | tnadiscovery100@gmail.com | abcd  | CAB 120 | CAB 120/1 | CAB 120/2 | CAB 120/3 | CAB 120/4 | CAB 120/5 | CAB 120/6 | CAB 120/7 | CAB 120/8 | CAB 120/9 | CAB 120/10 | CAB 120/11 | CAB 120/12 | CAB 120/13 | CAB 120/14 | CAB 120/15 | CAB 120/16 | CAB 120/17 | CAB 120/18 | CAB 120/19 | CAB 120/20 |

#Scenario Outline: bulkOrder_orderDocNow_40
#	Then check the page title, click on Order documents now
#	And enter forty document references "<series>","<DocRef1>","<DocRef2>","<DocRef3>","<DocRef4>","<DocRef5>","<DocRef6>","<DocRef7>","<DocRef8>","<DocRef9>","<DocRef10>","<DocRef11>","<DocRef12>","<DocRef13>","<DocRef14>","<DocRef15>","<DocRef16>","<DocRef17>","<DocRef18>","<DocRef19>","<DocRef20>","<DocRef21>","<DocRef22>","<DocRef23>","<DocRef24>","<DocRef25>","<DocRef26>","<DocRef27>","<DocRef28>","<DocRef29>","<DocRef30>","<DocRef31>","<DocRef32>","<DocRef33>","<DocRef34>","<DocRef35>","<DocRef36>","<DocRef37>","<DocRef38>","<DocRef39>","<DocRef40>"
#
#Examples:
#| readerTicketNo | firstName   | lastName   | email                     | telNo | series  | DocRef1   | DocRef2   | DocRef3   | DocRef4   | DocRef5   | DocRef6   | DocRef7   | DocRef8   | DocRef9   | DocRef10   | DocRef11   | DocRef12   | DocRef13   | DocRef14   | DocRef15   | DocRef16   | DocRef17   | DocRef18   | DocRef19   | DocRef20   | DocRef21   | DocRef22   | DocRef23   | DocRef24   | DocRef25   | DocRef26   | DocRef27   | DocRef28   | DocRef29   | DocRef30   | DocRef31   | DocRef32   | DocRef33   | DocRef34   | DocRef35   | DocRef36   | DocRef37   | DocRef38   | DocRef39   | DocRef40   |
#| 9487167        | firstTester | lastTester | tnadiscovery100@gmail.com | abcd  | CAB 120 | CAB 120/1 | CAB 120/2 | CAB 120/3 | CAB 120/4 | CAB 120/5 | CAB 120/6 | CAB 120/7 | CAB 120/8 | CAB 120/9 | CAB 120/10 | CAB 120/11 | CAB 120/12 | CAB 120/13 | CAB 120/14 | CAB 120/15 | CAB 120/16 | CAB 120/17 | CAB 120/18 | CAB 120/19 | CAB 120/20 | CAB 120/21 | CAB 120/22 | CAB 120/23 | CAB 120/24 | CAB 120/25 | CAB 120/26 | CAB 120/27 | CAB 120/28 | CAB 120/29 | CAB 120/30 | CAB 120/31 | CAB 120/32 | CAB 120/33 | CAB 120/34 | CAB 120/35 | CAB 120/36 | CAB 120/37 | CAB 120/38 | CAB 120/39 | CAB 120/40 |
Scenario: bulkOrder_orderDocLater
	When enter "<readerTicketNo>","<firstName>","<lastName>","<email>","<telNo>" and complete booking

	Then check the page title, click on Order documents later
	And check the page title, click on Yes, I’d like to order my documents later

Scenario Outline: bulkOrder_orderDocLater_No
	When enter "<readerTicketNo>","<firstName>","<lastName>","<email>","<telNo>" and complete booking

	Then check the page title, click on Order documents later
	And check the page title, click on No, I’d like to order my documents now
	And enter "<series>","<DocRef1>","<DocRef2>","<DocRef3>","<DocRef4>","<DocRef5>","<DocRef6>","<DocRef7>","<DocRef8>","<DocRef9>","<DocRef10>","<DocRef11>","<DocRef12>","<DocRef13>","<DocRef14>","<DocRef15>","<DocRef16>","<DocRef17>","<DocRef18>","<DocRef19>","<DocRef20>"

	Examples:
		| readerTicketNo | firstName   | lastName   | email                     | telNo | series  | DocRef1   | DocRef2   | DocRef3   | DocRef4   | DocRef5   | DocRef6   | DocRef7   | DocRef8   | DocRef9   | DocRef10   | DocRef11   | DocRef12   | DocRef13   | DocRef14   | DocRef15   | DocRef16   | DocRef17   | DocRef18   | DocRef19   | DocRef20   |
		| 9497872        | firstTester | lastTester | tnadiscovery100@gmail.com | abcd  | CAB 120 | CAB 120/1 | CAB 120/2 | CAB 120/3 | CAB 120/4 | CAB 120/5 | CAB 120/6 | CAB 120/7 | CAB 120/8 | CAB 120/9 | CAB 120/10 | CAB 120/11 | CAB 120/12 | CAB 120/13 | CAB 120/14 | CAB 120/15 | CAB 120/16 | CAB 120/17 | CAB 120/18 | CAB 120/19 | CAB 120/20 |

Scenario: bulkOrder_cancelVisit
Then check the page title, click on Order documents now
And click on cancel your visit, check the page title and proceed
And I can see the message Your visit has been cancelled on the top of the page