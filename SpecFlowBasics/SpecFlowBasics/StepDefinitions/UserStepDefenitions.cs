using AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowBasics.StepDefinitions
{
    [Binding]
    internal class UserStepDefenitions
    {
        [Given(@"I enter random user data")]
        public void GivenIEnterRandomUserData()
        {
            var person = new Fixture().Create<User>();

            Console.WriteLine($"Name: {person.Name}");
            Console.WriteLine($"Email: {person.Email}");
            Console.WriteLine($"Address: {person.Address}");
            Console.WriteLine($"Phone: {person.Phone}");

            var person2 = new Fixture().Build<User>()
                .With(x => x.Email, "Bert.VanItterbeeck@dotnetlabs.eu").Create();

            Console.WriteLine($"Name: {person2.Name}");
            Console.WriteLine($"Email: {person2.Email}");
            Console.WriteLine($"Address: {person2.Address}");
            Console.WriteLine($"Phone: {person2.Phone}");
        }

        [Given(@"I input a dynamic domain for the email of (.* email)")]
        public void GivenIInputADynamicDomainForTheEmailOfBert_VanItterbeeckDotnet_EuEmail(string email)
        {
            Console.WriteLine($"Email: {email}");
        }



    }


    public record User
    {
        public string Name { get; set; }
        public string Email { get; set; }  
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
