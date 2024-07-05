using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject.CustomArguments
{
    [Binding]
    public class CustomStepTransformer
    {
        [StepArgumentTransformation(@"(\d+) days from current date")]
        public DateTime DayAdderTransformer(int days)
        {
            return DateTime.Today.AddDays(days);
        }
    }
}
