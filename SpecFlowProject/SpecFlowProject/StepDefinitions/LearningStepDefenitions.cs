using TechTalk.SpecFlow.Assist;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public sealed class LearningStepDefenitions
    {
        [When(@"I fill all mandatory details in the form")]
        public void WhenIFillAllMandatoryDetailsInTheForm(Table table)
        {
            //var details = table.CreateSet<Employee>();
            //foreach (var item in details)
            //{
            //    Console.WriteLine($"Employee {item.Name} is {item.Age} years old.");
            //    Console.WriteLine($"The employee email is {item.Email}.");
            //    Console.WriteLine($"The employee phone number is {item.Phone}.");
            //}
            var details = table.CreateDynamicSet();
            foreach (var item in details)
            {
                Console.WriteLine($"Employee {item.Name} is {item.Age} years old.");
                Console.WriteLine($"The employee email is {item.Email}.");
                Console.WriteLine($"The employee phone number is {item.Phone}.");
            }

            // When using dynamic make sure that the attribute name is the same as the column name in the feature file.
        }
    }
}