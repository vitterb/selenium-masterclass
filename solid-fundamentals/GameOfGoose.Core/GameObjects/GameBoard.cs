using GameOfGoose.Factory;
using GameOfGoose.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GameOfGoose.GameObjects
{
    public class GameBoard
    {
        private SquareFactory squareFactory = new SquareFactory();
        public List<ISquare> Squares { get; } = new List<ISquare>();
        private static GameBoard instance;
        private GameBoard()
        {
            InitializeStandardSquares();
            InitializeGooseSquares();
            InitializeSpecialSquares();
        }

        private void InitializeSpecialSquares()
        {
            Squares[63] = squareFactory.Create(63, SquareTypes.End);
            Squares[58] = squareFactory.Create(58, SquareTypes.Death);
            Squares[52] = squareFactory.Create(52, SquareTypes.Prison);
            Squares[42] = squareFactory.Create(42, SquareTypes.Maze);
            Squares[31] = squareFactory.Create(31, SquareTypes.Well);
            Squares[19] = squareFactory.Create(19, SquareTypes.Inn);
            Squares[6] = squareFactory.Create(6, SquareTypes.Bridge);
        }

        private void InitializeGooseSquares()
        {
            var gooseSquareNumbers = new List<int>() { 5, 9, 14, 18, 23, 27, 32, 36, 41, 45, 50, 54, 59 };

            foreach (int gooseSquareNumber in gooseSquareNumbers)
            {
                int index = gooseSquareNumber;
                if (index < Squares.Count)
                {
                    Squares[index] = squareFactory.Create(index, SquareTypes.Goose);
                }
            }
        }

        private void InitializeStandardSquares()
        {
            for (int i = 0; i < 64; i++)
            {
                Squares.Add(squareFactory.Create(i, SquareTypes.Standard));
            }
        }
        public static GameBoard GetInstance()
        {
            if (instance == null)
            {
                instance = new GameBoard();
            }
            return instance;
        }
        public ISquare GetSquare(int SquareNumber)
        {
            return Squares.FirstOrDefault(x => x.Number == SquareNumber);
        }
    }
}