Feature: EmployeeDetails
	
	Feature set up for learning 

@Learning
Scenario: Create a new Employee with details
	#Given [context]
	When I fill all mandatory details in the form
	| Name | Age | Phone     | Email            |
	| Bert | 43  | 015797204 | Bert@example.net |
	| John | 32  | 015797205 | Jhon@example.org |
	| Mary | 23  | 015797206 | Mary@example.com |
