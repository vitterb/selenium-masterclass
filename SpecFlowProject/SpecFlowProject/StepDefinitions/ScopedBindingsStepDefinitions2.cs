using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject2.StepDefinitions
{
    [Binding]
    public sealed class ScopedBindingsStepDefinitions
    {
        [Given(@"I have opend the application")]
        [Scope(Scenario = "Login for Customer portal")]
        public void GivenIHaveOpendTheApplication()
        {
            Console.WriteLine("Customer is opening the application");
        }

        [Given(@"I log in to apllication")]
        [Scope(Scenario = "Login for Customer portal")]
        public void GivenILogInToApllication()
        {
            Console.WriteLine("Customer is logging in to application");
        }

        [Then(@"I see customer portal")]
        public void ThenISeeCustomerPortal()
        {
            Console.WriteLine("Customer is seeing the customer portal");
        }

    }
}
