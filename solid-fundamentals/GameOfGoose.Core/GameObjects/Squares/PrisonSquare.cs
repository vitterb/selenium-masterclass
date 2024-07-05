using GameOfGoose.Factory;
using GameOfGoose.Interfaces;

namespace GameOfGoose.GameObjects.Squares
{
    public class PrisonSquare : ISquare
    {
        public int Number { get; set; }
        public SquareTypes Type { get; set; }

        public PrisonSquare(int number, SquareTypes type)
        {
            Number = number;
            Type = type;
        }

        public void Action(IPlayer player)
        {
            if (!player.IsPrisoner)
            {
                player.SkipCounter = 3;
                player.IsPrisoner = true;
            }
        }
    }
}