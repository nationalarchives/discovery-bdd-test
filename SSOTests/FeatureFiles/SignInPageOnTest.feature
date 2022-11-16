Feature: SignInPageOnTest

Background:
	Given I am on home page and click on signin

Scenario Outline: signing in with empty username
	When I enter only "<pswd>" without username and trying to signin
	Then I should see the validation message Please enter your email address

	Examples:
		| pswd     |
		| abcdef   |
		| testpswd |

Scenario Outline: signing in with empty password
	When I enter only "<email>" without password and trying to signin
	Then I should see the validation message Please enter your password

	Examples:
		| email               |
		| testsix@gmail.com   |
		| testseven@gmail.com |

Scenario: signin with no email and no password
	When I don't enter anything and trying to signin
	Then I should see the validation messages Please enter your email address and Please enter your password

Scenario Outline: PersonalDetails
	When I sign in with "<username>" and "<password>" and go to personal details
	Then I should see the text Click here to change your password

	Examples:
		| username                  | password   |
		| tnadiscovery100@gmail.com | Test123456 |

Scenario Outline: signinSignOut

When I search "<keyWord>" on homePage
And redirect to results page, go to details page, sign out
Then I should be on the details page
Examples: 
| keyWord |
| george  |
| WO 95   |