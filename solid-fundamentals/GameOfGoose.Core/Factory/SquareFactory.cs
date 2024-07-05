using GameOfGoose.GameObjects;
using GameOfGoose.GameObjects.Squares;
using GameOfGoose.Interfaces;
using System;

namespace GameOfGoose.Factory
{
    internal class SquareFactory
    {
        public ISquare Create(int number, SquareTypes type)
        {
            ISquare square;

            switch (type)
            {
                case SquareTypes.Standard:
                    square = new StandardSquare(number, type);
                    break;

                case SquareTypes.Goose:
                    square = new GooseSquare(number, type);
                    break;

                case SquareTypes.Bridge:
                    square = new BridgeSquare(number, type);
                    break;

                case SquareTypes.Inn:
                    square = new InnSquare(number, type);
                    break;

                case SquareTypes.Well:
                    square = new WellSquare(number, type);
                    break;

                case SquareTypes.Maze:
                    square = new MazeSquare(number, type);
                    break;

                case SquareTypes.Prison:
                    square = new PrisonSquare(number, type);
                    break;

                case SquareTypes.Death:
                    square = new DeathSquare(number, type);
                    break;

                case SquareTypes.End:
                    square = new EndSquare(number, type);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, "Invalid square type.");
            }
            return square;
        }
    }
}