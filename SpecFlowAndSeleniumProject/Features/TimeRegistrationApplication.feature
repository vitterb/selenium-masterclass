Feature: TimeRegistrationApplication

Testing the verious functionalities of the TimeRegistrationApplication

@Home
Scenario: Check if the home page loads correctly.
	Given I go to the application HomePage
	Then I should see "Masterclass Time registration app" as title

@Home 
Scenario: Check if the User page link works correctly.
	Given I go to the application HomePage
	When I click on the User page link
	Then I should have navigated to the User page

@Home
Scenario: Check if the Company page link works correctly.
	Given I go to the application HomePage
	When I click on the Company page link
	Then I should have navigated to the company page

@Home
Scenario: Check if the TimeRegistration page link works correctly.
	Given I go to the application HomePage
	When I click on the TimeRegistration page link
	Then I should have navigated to the timeRegistration page

@Users
Scenario: Check if the Users page loads correctly.
	Given I go to the application UsersPage
	Then I should see "Users" as title

@Users
Scenario: I go to the userpage and create, edit and delete a user
	Given I go to the application UsersPage
	When I add a new user name in the input field
	And I select the company from the company dropdown menu
	And I click on the add user button
	Then I should see the user in the user table with the correct company
	When I click on the edit button of the user
	Then I get the update menu
	When I change the user name in the updateField
	And I change the company in the updatecompany dropdown menu
	And I click the update user button
	Then I should see the updated user in the user table with the correct company
	When I click on the delete button of the user
	Then I should not see the user in the user table

@Users 
Scenario: Check if the HomePage Link works from the user page.
	Given I go to the application UsersPage
	When I click on the HomePage link
	Then I should have navigated to the HomePage

@Users
Scenario: Check if the Company page link works from the user page.
	Given I go to the application UsersPage
	When I click on the Company page link
	Then I should have navigated to the company page

@Users
Scenario: Check if the TimeRegistration link works from the user page.
	Given I go to the application UsersPage
	When I click on the TimeRegistration page link
	Then I should have navigated to the timeRegistration page

@Company
Scenario: Check if the Company page loads correctly.
	Given I go to the application CompanyPage
	Then I should see "Companies" as title

@Company
Scenario: Check if the HomePage link works from the company page.
	Given I go to the application CompanyPage
	When I click on the HomePage link
	Then I should have navigated to the HomePage

@Company
Scenario: Check if the User page link works from the company page.
	Given I go to the application CompanyPage
	When I click on the User page link
	Then I should have navigated to the User page

@Company
Scenario: Check if the TimeRegistration page link works from the company page.
	Given I go to the application CompanyPage
	When I click on the TimeRegistration page link
	Then I should have navigated to the timeRegistration page

@Company
Scenario: I go to the company page and create and delete a company
	Given I go to the application CompanyPage
	When I add a new company name in the input field
	And I click on the add company button
	Then I should see the company in the company table
	When I click on the delete button of the company
	Then I should not see the company in the company table