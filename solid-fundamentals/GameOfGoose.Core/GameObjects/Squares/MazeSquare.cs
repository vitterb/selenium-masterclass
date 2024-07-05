using GameOfGoose.Factory;
using GameOfGoose.Interfaces;

namespace GameOfGoose.GameObjects.Squares
{
    public class MazeSquare : ISquare
    {
        public int Number { get; set; }
        public SquareTypes Type { get; set; }

        public MazeSquare(int number, SquareTypes type)
        {
            Number = number;
            Type = type;
        }

        public void Action(IPlayer player)
        {
            {
                player.MoveToSpace(39);
            }
        }
    }
}