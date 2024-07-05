Feature: SpecFlowExcell

A short summary of the feature

@DataSource:..\SpecFlowExcel.xlsx @DataSet:Sheet1 @specflowExcel
Scenario Outline: Add Numbers
	Given I have entered <num1> into the calculator
	And I have entered <num2> into the calculator
	When I press add
	Then The result should be <result> on the screen

#To Run via Excell DON'T use specflow.plus.excell but use Specflow.externalData

