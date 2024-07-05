using SpecFlowProject.TestEntity;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            Console.WriteLine(number);
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            Console.WriteLine(number);
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            Console.WriteLine("pressed Add Button");
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            if (result == 120) // Grab the object whiw=ch has the value of 120 in the UI of the real application and replace.
            {
                Console.WriteLine("Test Passed");
            }
            else
            {
                Console.WriteLine("Test Failed");
                throw new Exception("Values are different");
            }
        }

        [When(@"I enter the employee details in form")]
        public void WhenIEnterTheEmployeeDetailsInForm(Table table)
        {
            //Employee details =  table.CreateInstance<Employee>();
            //Console.WriteLine($"Emplayee Name is {details.Name}, Employee age is {details.Age}, Employee Email is {details.Email}, Employee phone is 0{details.Phone}.");

            var details = table.CreateSet<Employee>();
            foreach (var item in details)
            {
                Console.WriteLine($"Emplayee Name is {item.Name}, Employee age is {item.Age}, Employee Email is {item.Email}, Employee phone is 0{item.Phone}.");
            }
        }

        [When(@"I enter the employee details in form (.*), (.*), (.*) and (.*)")]
        public void WhenIEnterTheEmployeeDetailsInFormBertAndBertExample_Net(string name, int age, Int64 phone, string email)
        {
            Console.WriteLine(name + " " + age + " " + phone + " " + email);

            ScenarioContext.Current["InfoForNextStep"] = "Step1 Passed!";

            Console.WriteLine(ScenarioContext.Current["InfoForNextStep"].ToString());

            List<Employee> employeesList = new List<Employee>()
            {
                new Employee()
                {
                    Name = "Test",
                    Age = 18,
                    Phone = 015777777,
                    Email = "test@example.net"
                },
                new Employee()
                {
                    Name = "Test2",
                    Age = 20,
                    Phone = 015777778,
                    Email = "test2@example.net"
                },
                new Employee()
                {
                    Name = "Test3",
                    Age = 30,
                    Phone = 015777777,
                    Email = "test3@example.net"
                }
            };

            // save the value in scenario context

            ScenarioContext.Current.Add("EmployeeList", employeesList);

            //Get The Value from Scenario Context
            var empList = ScenarioContext.Current.Get<IEnumerable<Employee>>("EmployeeList");

            foreach (var item in empList)
            {
                Console.WriteLine($"Emplayee Name is {item.Name}, Employee age is {item.Age}, Employee Email is {item.Email}, Employee phone is 0{item.Phone}.");
            }

            Console.WriteLine(ScenarioContext.Current.ScenarioInfo.Title);
            Console.WriteLine(ScenarioContext.Current.CurrentScenarioBlock);
        }
    }
}