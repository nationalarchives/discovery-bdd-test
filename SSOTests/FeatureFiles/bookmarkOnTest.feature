Feature: bookmarkOnTest
	Here we are testing all the functionalities of bookmark button

@mytag
Scenario Outline: bookmark_add_Rename_Delete
	Given I signed in and navigate to details page for <Iaid>
		And click on cookies, hide this message

	When I click on bookmark link and add the bookmark
	Then check for the bookmarks successfully added or not
	And Rename, delete the bookmark, check for the delete messages

	Examples:
		| Iaid      |
		| C7351413  |
		| C4107320  |
		| C14016701 |