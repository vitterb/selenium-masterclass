using SpecFlowProject.TestEntity;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public sealed class ContextInjextionStepDefinitions
    {
        public readonly Employee employee;
        public ContextInjextionStepDefinitions(Employee emp)
        {
            this.employee = emp;
        }

        [When(@"I fill all the details in form")]
        public void WhenIFillAllTheDetailsInForm(Table table)
        {
            var details = table.CreateDynamicSet();
            foreach (var item in details)
            {
                Console.WriteLine($"Employee {item.Name} is {item.Age} years old.");
                employee.Name = (string)item.Name;
                employee.Age = (int)item.Age; 
                Console.WriteLine($"The employee email is {item.Email}.");
                employee.Email = (string)item.Email;
                Console.WriteLine($"The employee phone number is {item.Phone}.");
                employee.Phone = (Int64)item.Phone;
            }
        }


    }
}