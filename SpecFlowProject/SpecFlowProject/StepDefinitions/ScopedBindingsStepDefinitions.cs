using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public sealed class ScopedBindingsStepDefinitions
    {
        [Given(@"I have opend the application")]
        [Scope(Tag ="User")]
        public void GivenIHaveOpendTheApplication()
        {
            Console.WriteLine("User is opening the application");
        }

        [Given(@"I log in to apllication")]
        [Scope(Feature ="UserLogin")]
        public void GivenILogInToApllication()
        {
            Console.WriteLine("User is logging in to application");
        }

        [Then(@"I see user portal")]
        public void ThenISeeUserPortal()
        {
            Console.WriteLine("User is seeing the user portal");
        }     
    }
}
