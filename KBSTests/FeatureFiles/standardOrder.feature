Feature: standardOrder

Background:
	Given Go to KBS page for standard order
	When click on Select a date under book a standard order visit
	And click on date in the first row for standard order
	And enter "<readerTicketNo>","<firstName>","<lastName>","<email>","<telNo>" and complete booking for standard order

Scenario Outline: standardOrder_orderDocNow
	Then check the page title, click on Order documents now for standard order
	And enter two document references "<DocRef1>","<DocRef2>", enter "<ReserveDocRef1>"

	Examples:
		| DocRef1     | DocRef2     | ReserveDocRef1 |
		| CAB 132/172 | SC 2/200/57 | ED 24/1123     |
Scenario Outline: standardOrder_orderDocLater
Then check the page title, click on Order documents later for standard order


Scenario: bulkOrder_cancelVisit
	Then check the page title, click on Order documents now for standard order
And click on cancel your visit, check the page title and proceed for standard order
And I can see the message Your visit has been cancelled