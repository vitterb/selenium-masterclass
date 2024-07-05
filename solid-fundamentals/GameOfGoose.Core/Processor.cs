using GameOfGoose.GameObjects;
using GameOfGoose.Interfaces;
using System;
using System.Collections.Generic;

namespace GameOfGoose
{
    public class Processor
    {
        public int Turn { get; set; }
        public GameBoard Board { get; set; }
        public List<IPlayer> players = new List<IPlayer>();
        public ILogger Logger { get; set; }
        public IDice Dice { get; set; }
        public int Result { get; set; }

        public Processor(ILogger logger)
        {
            Board = GameBoard.GetInstance();
            Logger = logger;
            Dice = new Dice();
            Turn = 1; ;
        }

        public int EnterPlayerNumbers()
        {
            Console.Write("How many players 2 - 4 ?");
            int numberOfPlayers = Int32.Parse(Console.ReadLine());
            return numberOfPlayers;
        }

        public void InitializeGame(int numberOfPlayers)
        {
            if (numberOfPlayers < 2)
            {
                Logger.Info("Less than 2 players is not Allowed!");
                InitializeGame(EnterPlayerNumbers());
            }
            else if (numberOfPlayers > 4)
            {
                Logger.Info("More than 4 Players is not Allowed!");
                InitializeGame(EnterPlayerNumbers());
            }
            else
            {
                for (int i = 1; i <= numberOfPlayers; i++)
                {
                    players.Add(new Player($"player{i}"));
                }
                NextTurn();
            }
        }

        public void ProcessPlayerTurn(int Roll1, int Roll2, int turn, IPlayer player)
        {
            int smallerRoll = Math.Min(Roll1, Roll2);
            int largerRoll = Math.Max(Roll1, Roll2);
            Result = Roll1 + Roll2;

            if (player.IsWaiting)
            {
                Result = 0;
            }
            if (player.SkipCounter != 0)
            {
                player.SkipCounter--;
                Result = 0;
            }
            if (Result == 9 && turn == 1)
            {
                HandleSpecialFirstRoll(player, smallerRoll, largerRoll);
            }
            else
            {
                player.Move(Result);
                ResetPlayerAttributes(player);
            }

            ExecuteSquareRules(player);
        }

        private void ExecuteSquareRules(IPlayer player)
        {
            ISquare square = Board.GetSquare(player.Position);

            square.Action(player);
        }

        private static void HandleSpecialFirstRoll(IPlayer player, int smallerRoll, int largerRoll)
        {
            if ((smallerRoll == 3 && largerRoll == 6) || (smallerRoll == 4 && largerRoll == 5))
            {
                player.MoveToSpace((smallerRoll == 3 && largerRoll == 6) ? 53 : 26);
            }
        }

        private static void ResetPlayerAttributes(IPlayer player)
        {
            if (player.Position != 52 && player.Position != 19)
            {
                player.IsVisitingInn = false;
                player.IsPrisoner = false;
            }
        }

        private void NextTurn()
        {
            Logger.Info($"Turn {Turn}");
            string output = "P1 \t \t P2 \t \t P3 \t \t  P4 \n";
            foreach (IPlayer p in players)
            {
                ProcessPlayerTurn(Dice.Roll(), Dice.Roll(), Turn, p);
                output += p.Position + " ";
                ISquare square = Board.GetSquare(p.Position);
                output += square.Type + " (" + Result.ToString() + ") " +
                    "\t";

                if (p.GameOver)
                {
                    Logger.Info(output);
                    EndOfGame();
                }
            }
            output += "\n";
            Logger.Info(output);
            Turn++;

            Logger.Info("Press ENTER to play the next turn!");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
                NextTurn();
        }

        private void EndOfGame()
        {
            Logger.Info("There is a winner");
            System.Environment.Exit(0);
        }
    }
}