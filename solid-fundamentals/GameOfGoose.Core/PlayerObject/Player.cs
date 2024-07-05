using GameOfGoose.GameObjects;
using GameOfGoose.Interfaces;

namespace GameOfGoose
{
    public class Player : IPlayer
    {
        public string Name { get; }
        public int Position { get; set; }
        public bool GameOver { get; set; }
        public bool IsWaiting { get; set; }
        public bool IsMovingForward { get; set; }
        public int SkipCounter { get; set; }
        public bool IsPrisoner { get; set; }
        public bool IsVisitingInn { get; set; }
        public int LastThrow { get; set; }

        public Player(string name)
        {
            Name = name;
            Position = 0;
            IsMovingForward = true;
        }

        public void StartWaiting()
        {
            IsWaiting = true;
        }

        public void StopWaiting()
        {
            IsWaiting = false;
        }

        public void MoveToSpace(int squareNumber)
        {
            Position = squareNumber;
        }

        public void Move(int diceThrow)
        {
            Position += diceThrow;
            LastThrow = diceThrow;

            if (Position >= GameBoard.GetInstance().Squares.Count)
            {
                IsMovingForward = false;
                int overshootAmount = Position - (GameBoard.GetInstance().Squares.Count - 1);
                Position = GameBoard.GetInstance().Squares.Count - 1 - overshootAmount;
            }
        }
    }
}