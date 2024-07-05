using GameOfGoose.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfGoose.Logger
{
    public class ConsoleLogger : ILogger
    {
        public void Info(string message)
        {
           Console.WriteLine(message);
        }
    }
}
