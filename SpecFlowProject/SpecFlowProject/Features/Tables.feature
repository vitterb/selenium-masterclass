Feature: Tables

A short summary of the feature

@MultipleDataUsingTables
Scenario: Create New Employeee with mandatory details
	#Given I have opend my application
	#Then I should see employee deatails page
	When I enter the employee details in form
	| Name | Age | Phone     | Email            |
	| Bert | 43  | 015797204 | Bert@example.net |
	| John | 32  | 015797205 | Jhon@example.org |
	| Mary | 23  | 015797206 | Mary@example.com |
	#And I click on the save button
	#Then I should see all the deatails saved in my apllication and DB

@MultipleDataUsingTables
Scenario Outline: Create New Employee with mandatory details
	#Given I have opend my application
	#Then I should see employee deatails page
	When I enter the employee details in form <Name>, <Age>, <Phone> and <Email>
	#And I click on the save button
	#Then I should see all the deatails saved in my apllication and DB
Examples:
	| Name | Age | Phone     | Email            |
	| Bert | 43  | 015797204 | Bert@example.net |
	| John | 32  | 015797205 | Jhon@example.org |
	| Mary | 23  | 015797206 | Mary@example.com |