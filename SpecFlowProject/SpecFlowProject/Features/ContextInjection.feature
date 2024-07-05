Feature: ContextInjections

A short summary of the feature

@Learning
Scenario: Check if I could get the details entered via Table from extended Steps
	When I fill all the details in form
	| Name | Age | Phone    | Email            |
	| Bert | 43  | 15797204 | bert@example.org |
	Then I should get the same value from extended steps
