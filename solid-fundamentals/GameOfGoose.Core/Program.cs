using GameOfGoose.Interfaces;
using GameOfGoose.Logger;
using System;

namespace GameOfGoose
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();

            Processor processor = new Processor(logger);

            int numberOfPlayers = processor.EnterPlayerNumbers();

            processor.InitializeGame(numberOfPlayers);
        }
    }
}