using AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowBasics.Transformer
{
    [Binding]
    public  class EmailTransformer
    {
        [StepArgumentTransformation(@"(.*) email")]
        public string GenerateDynamicEmailAdress(string emailAdress) => emailAdress.Split("@")[0] +  "@" + GetRandomDomain();

        private string GetRandomDomain() => new Fixture().Create<MailAddress>().Host;
    }
}
