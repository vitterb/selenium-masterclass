Feature: Calculator
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](SpecFlowBasics/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@mytag
Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be "PASSED"

Scenario: Working with Tables
	Given I input following numbers to the Calculator
		| Numbers |
		| 50      |
		| 70      |
	When the two numbers are added
	Then I see the result and a few more Details
		| Result | Logo |
		| 120	 | +    |
	Then the result should be "PASSED"