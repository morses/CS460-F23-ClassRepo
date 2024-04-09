@Scot
Feature: Home "Hello World" for Reqnroll and Selenium

A short summary of the feature


Scenario: Home page title contains Standup Meetings
	Given I am a visitor
	When I am on the "Home" page
	Then The page title contains "Standup Meetings"

Scenario: Home page has a Register button
	Given I am a visitor
	When I am on the "Home" page
	Then The page presents a Register button

Scenario: Home page has an email submission form to receive newsletter
	Given I am a visitor
	When I am on the "Home" page
	Then I should see an input to submit my email address

Scenario: Home page can submit email for newsletter
	Given I am a visitor
	 And  I am on the "Home" page
	When I enter in my valid email address to subscribe
	 And I subscribe
	Then I will see some sort of a success message

