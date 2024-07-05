using GameOfGoose.Factory;
using GameOfGoose.Interfaces;

namespace GameOfGoose.GameObjects.Squares
{
    public class DeathSquare : ISquare
    {
        public int Number { get; set; }
        public SquareTypes Type { get; set; }

        public DeathSquare(int number, SquareTypes type)
        {
            Number = number;
            Type = type;
        }

        public void Action(IPlayer player)
        {
            player.Position = 0;
        }
    }
}