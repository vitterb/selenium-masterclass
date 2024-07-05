using SpecFlowProject.TestEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public sealed class ExtendedStepsLearning 
    {
        public readonly Employee employee;
        
        public ExtendedStepsLearning(Employee emp)
        {
            this.employee = emp;
        }

        [Then(@"I should get the same value from extended steps")]
        public void ThenIShouldGetTheSameValueFromExtendedSteps()
        {
            Console.WriteLine($"Employee {employee.Name} is {employee.Age} years old.");
            Console.WriteLine($"The employee email is {employee.Email}.");
            Console.WriteLine($"The employee phone number is {employee.Phone}.");
        }
    }
}
