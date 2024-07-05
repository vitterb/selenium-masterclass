using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public sealed class StepArgumentTransformationStepDefinitions
    {
        [Given(@"I have opened the apllication")]
        public void GivenIHaveOpenedTheApllication()
        {
            Console.WriteLine("I have opened the application");
        }

        [Given(@"I login to the apllication as admin")]
        public void GivenILoginToTheApllicationAsAdmin()
        {
            Console.WriteLine("I login to the application as admin");
        }

        [Then(@"I see last date logged in data is (.* days from current date)")]
        public void ThenISeeLastDateLoggedInDataIsDaysFromCurrentDate(DateTime correctDateTime)
        {
            Console.WriteLine(correctDateTime.ToString("dd/MM/yyyy"));
        }
        [Then(@"I see the menus like")]
        public void ThenISeeTheMenusLike(IEnumerable<dynamic> menuList)
        {
            // If public void ThenISeeTheMenusLike(Table menus)
            //dynamic menu = menus.CreateDynamicInstance();

            //string menu1 = menu.Menu_1;
            //string menu2 = menu.Menu_2;
            //string menu3 = menu.Menu_3;
            //string menu4 = menu.Menu_4;

            //Console.WriteLine("Menu 1 is {0} en Menu 2 is {1} ", menu1, menu2) ;

            //IEnumerable<dynamic> menuList = menus.CreateDynamicSet();

            //var menuSet = menuList.First();

            //string menuSet1 = menuSet.Menu_1;
            //string menuSet2 = menuSet.Menu_2;
            //string menuSet3 = menuSet.Menu_3;
            //string menuSet4 = menuSet.Menu_4;

            //Console.WriteLine("MenuSet 1 is {0} en MenuSet 2 is {1} ", menuSet1, menuSet2);

            //For this to work you must add the following to the Specflow.json file:
//             {
//                "stepAssemblies": [
//                  { "assembly": "specflow.Assist.Dynamic" }
//                ]
//              }
            var menu = menuList.First();

            string menu1 = menu.Menu_1; 
            string menu2 = menu.Menu_2;
            string menu3 = menu.Menu_3;
            string menu4 = menu.Menu_4;

            Console.WriteLine("The value of menu1 is {0}", menu1);
            Console.WriteLine("The value of menu2 is {0}", menu2);
            Console.WriteLine("The value of menu3 is {0}", menu3);
            Console.WriteLine("The value of menu4 is {0}", menu4);
        }

    }
}
