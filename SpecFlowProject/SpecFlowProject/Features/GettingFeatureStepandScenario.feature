Feature: GettingFeatureStepandScenario

dummy steps to find scenario, feature and step

@Getting
Scenario: Check login
	Given I have navigated to the application
	And I see the apllication has opend
	Then I click on login link
	When I enter username and password
	| username | password |
	| admin    | admin    |
	Then I click on login button
	Then I should see the username with welcome message
	Then I click logout button