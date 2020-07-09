Feature: whatToExpectGuide

Scenario Outline: DidYouFindThisGuideHelpful
	Given I am on the details page for "<iaId>" for offSite
	When click on "<button>" for Did you find this guide helpful
	And check for the "<heading>" and "<commentHeading>"
	Then enter "<feedback>", "<acknowledge>"

	Examples:
		| iaId      | button                                                     | heading                                     | commentHeading                                                                          | feedback       | acknowledge                 |
		| C7352683  | //*[@id="what-to-expect-form"]/div/form/fieldset/button[1] | We'd like to hear from you                  | Your feedback helps us improve our services. Please share any comments below (optional) | This is a Test | Thank you for your feedback |
		| C7352683  | //*[@id="what-to-expect-form"]/div/form/fieldset/button[2] | Please let us know why you are dissatisfied | Your feedback helps us improve our services. Please share any comments below            | This is a Test | Thank you for your feedback |
		| C14017296 | //*[@id="what-to-expect-form"]/div/form/fieldset/button[1] | We'd like to hear from you                  | Your feedback helps us improve our services. Please share any comments below (optional) | This is a Test | Thank you for your feedback |
		| C14017296 | //*[@id="what-to-expect-form"]/div/form/fieldset/button[2] | Please let us know why you are dissatisfied | Your feedback helps us improve our services. Please share any comments below            | This is a Test | Thank you for your feedback |

Scenario Outline: readMore_researchGuide
	Given I am on the details page for "<iaId>" for offSite
	When click on Read more, click on research guide
	Then check for the page title

	Examples:
		| iaId      |
		| C14017295 |
		| C14053146 |
		| C14053152 |

Scenario Outline: readMore_readLess
	Given I am on the details page for "<iaId>" for offSite
	When click on Read more
	Then click on Read less

	Examples:
		| iaId      |
		| C14053147 |
		| C14017295 |

Scenario Outline: ViewExampleRecord
Given I am on the details page for "<iaId>" for offSite
When click on View a page feom an example war diary
Then check for the title example record only
Examples: 
| iaId      |
| C14016702 |
| C14053146 |