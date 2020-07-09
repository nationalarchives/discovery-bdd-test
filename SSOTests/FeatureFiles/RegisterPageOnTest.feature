Feature: Register page

Background:
	Given I am on Registration page

Scenario: click register with empty fields
Here we are checking all the validation messages
	When I click on Register without entering anything
	Then I can see validation messages

Scenario Outline: register with invalid mismatch email and  password
	When I enter "<name>","<email>","<confirmEmail>","<pswd>","<confirmPswd>" in registration page
	Then I should see the "<emailValidationMessage>" if "<email>","<confirmEmail>" mismatch
	And I should see "<pswdValidationMessage>" if "<pswd>","<confirmPswd>" mismatch in registration page

	Examples:
		| name   | email                     | confirmEmail                   | pswd          | confirmPswd   | emailValidationMessage                                         | pswdValidationMessage                                |
		| Test   | tnadiscovery100@gmail.com | tnadiscovery100@gmaillllll.com | Discovery1234 | Discovery1234 | The email address and confirmation email address do not match. | The password and confirmation password do not match. |
		| Tester | discovery12345@gmail.com  | discovery12345@gmail.com       | Test1234567   | Test1234      | The email address and confirmation email address do not match. | The password and confirmation password do not match. |

Scenario Outline: create account
	When I enter "<name>","<email>","<confirmEmail>","<pswd>","<confirmPswd>" in registration page
	Then I should see "<verifyEmailMsg>"

	Examples:
		| name | email                     | confirmEmail              | pswd       | confirmPswd | verifyEmailMsg    |
		| Test | tnadiscovery100@gmail.com | tnadiscovery100@gmail.com | Test123456 | Test123456  | Verify your email |

Scenario Outline: create account, change email, change password, delete account
	When signin with "<oldId>","<oldPswd>", go to your personal details, change email "<newEmail>"
	And signin with "<newEmail>", "<oldPswd>"
	And for change password go to your personal details, change password
	And for change password enter  "<oldPswd>","<newPassword>","<confirmNewPassword>"
	Then sign in using "<newEmail>","<newPassword>"
	And delete the account and check for "<accountDeletionMessage>"

	Examples:
		| name | verifyEmailMsg    | oldId                     | oldPswd    | newEmail             | newPassword | confirmNewPassword | accountDeletionMessage                                      |
		| Test | Verify your email | tnadiscovery100@gmail.com | Test123456 | tnatest595@gmail.com | Test1234    | Test1234           | Your account has been closed and your account data deleted. |

Scenario Outline: forgotten password
	When click on signin, forgotten your password, enter "<email>"
	Then check for the reset your password message

	Examples:
		| email                     |
		| tnadiscovery100@gmail.com |
		| testseven@gmail.com       |

Scenario Outline: Don't accept privacy and cookie policies
	When I enter "<name>","<email>","<confirmEmail>","<pswd>","<confirmPswd>" but don't tick T&C and register
	Then check for the validation message You must accept the terms and conditions

	Examples:
		| name   | email                     | confirmEmail              | pswd          | confirmPswd   |
		| Test   | tnadiscovery100@gmail.com | tnadiscovery100@gmail.com | Discovery1234 | Discovery1234 |
		| Tester | discovery12345@gmail.com  | discovery12345@gmail.com  | Test1234      | Test1234      |