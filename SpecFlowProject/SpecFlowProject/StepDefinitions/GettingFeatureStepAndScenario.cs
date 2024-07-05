using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    internal class GettingFeatureStepAndScenario
    {
        [Given(@"I have navigated to the application")]
        public void GivenIHaveNavigatedToTheApllication()
        {
            Console.WriteLine("Dummy Step");
        }

        [Given(@"I see the apllication has opend")]
        public void GivenISeeTheApllicationHasOpend()
        {
            Console.WriteLine("Dummy Step");
        }

        [Then(@"I click on login link")]
        public void ThenIClickOnLoginLink()
        {
            Console.WriteLine("Dummy Step");
        }

        [When(@"I enter username and password")]
        public void WhenIEnterUsernameAndPassword(Table table)
        {
            Console.WriteLine("Dummy Step");
        }

        [Then(@"I click on login button")]
        public void ThenIClickOnLoginButton()
        {
            Console.WriteLine("Dummy Step");
        }

        [Then(@"I should see the username with welcome message")]
        public void ThenIShouldSeeTheUsernameWithWelcomeMessage()
        {
            Console.WriteLine("Dummy Step");
        }

        [Then(@"I click logout button")]
        public void ThenIClickLogoutButton()
        {
            Console.WriteLine("Dummy Step");
        }

    }
}
