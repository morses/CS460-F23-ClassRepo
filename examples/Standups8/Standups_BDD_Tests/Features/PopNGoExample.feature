Feature: Ability to create personalized lists and bookmark events

	Given I am on the favorites page

	Then I should see a list of bookmark lists containing a name and quantity of events in each list

	And a button to add a new bookmark list.

	- We need to be logged in, so we need an actual user
	- there should already be on bookmark list on that page
	- this one is more of a hello world that the list and a button exist

Background:
	Given the following users exist
	  | UserName   | Email                 | FirstName | LastName | Password  |
	  | TaliaK     | knott@example.com     | Talia     | Knott    | Hello123# |

Scenario: There is a bookmark list and a add new bookmark list on the favorites page
	Given I am a user with first name 'Talia'
	 And  I login
	When I am on the "Favorites" page
	Then I should see a bookmark list
	 And I should see a way to create a new bookmark list

Scenario: I can add a new bookmark list
	Given I am a user with first name 'Talia'
	 And  I login
	 And I am on the "Favorites" page
	When I fill out and submit the new bookmark form having a unique title 
#with key newbookmarklisttitle
	Then I should see the new bookmark list displayed