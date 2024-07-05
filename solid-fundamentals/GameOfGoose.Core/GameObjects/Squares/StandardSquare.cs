using GameOfGoose.Factory;
using GameOfGoose.Interfaces;

namespace GameOfGoose.GameObjects.Squares
{
    internal class StandardSquare : ISquare
    {
        public int Number { get; set; }
        public SquareTypes Type { get; set; }

        public StandardSquare(int number, SquareTypes type)
        {
            Number = number;
            Type = type;
        }

        public void Action(IPlayer player)
        {
        }
    }
}