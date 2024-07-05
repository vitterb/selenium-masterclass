using GameOfGoose.Factory;
using GameOfGoose.GameObjects;

namespace GameOfGoose.Interfaces
{
    public interface ISquare
    {
        int Number { get; set; }
        SquareTypes Type { get; set; }
        void Action(IPlayer player);
    }
}