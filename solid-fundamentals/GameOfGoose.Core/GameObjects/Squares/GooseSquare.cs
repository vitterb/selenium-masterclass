using GameOfGoose.Factory;
using GameOfGoose.Interfaces;
using System;

namespace GameOfGoose.GameObjects.Squares
{
    public class GooseSquare : ISquare
    {
        public int Number { get; set; }
        public SquareTypes Type { get; set; }

        public GooseSquare(int number, SquareTypes type)
        {
            this.Number = number;
            this.Type = type;
        }

        public void Action(IPlayer player)
        {
            if (player.IsMovingForward)
            {
                player.Move(player.LastThrow);

                if (player.Position >= GameBoard.GetInstance().Squares.Count)
                {
                    player.IsMovingForward = false;
                    int overshootAmount = player.Position - (GameBoard.GetInstance().Squares.Count - 1);
                    player.Position = GameBoard.GetInstance().Squares.Count - 1 - overshootAmount;
                }
            }
            if (!player.IsMovingForward)
            {
                player.Position -= player.LastThrow;
            }
            player.IsMovingForward = true;
        }
    }
}
    
