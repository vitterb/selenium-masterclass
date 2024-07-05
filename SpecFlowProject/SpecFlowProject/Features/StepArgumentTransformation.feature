Feature: StepArgumentTransformation

A short summary of the feature

@StepArgumentTransformation
Scenario: Adding days to current date
	Given I have opened the apllication
	And I login to the apllication as admin
	Then I see last date logged in data is 5 days from current date
	And I see the menus like
	| Menu_1 | Menu_2   | Menu_3 | Menu_4   |
	| login  | settings | logout | Advanced |
