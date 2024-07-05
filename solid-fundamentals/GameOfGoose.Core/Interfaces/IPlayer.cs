using GameOfGoose.GameObjects;

namespace GameOfGoose.Interfaces
{
    public interface IPlayer
    {
        bool GameOver { get; set; }
        bool IsWaiting { get; set; }
        string Name { get; }
        int Position { get; set; }
        bool IsMovingForward { get; set; }
        int SkipCounter { get; set; }
        bool IsPrisoner { get; set; }
        bool IsVisitingInn { get; set; }
        int LastThrow { get; set; }

        void StartWaiting();

        void StopWaiting();

        void MoveToSpace(int squareNumber);

        void Move(int dicethrow);
    }
}