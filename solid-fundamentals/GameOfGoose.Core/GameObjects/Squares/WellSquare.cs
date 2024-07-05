using GameOfGoose.Factory;
using GameOfGoose.Interfaces;
using System.Collections.Generic;

namespace GameOfGoose.GameObjects.Squares
{
    public class WellSquare : ISquare
    {
        public int Number { get; set; }
        public SquareTypes Type { get; set; }
        private List<IPlayer> waitingPlayers = new List<IPlayer>();

        public WellSquare(int number, SquareTypes type)
        {
            Number = number;
            Type = type;
        }

        public void Action(IPlayer player)
        {
            if (!player.IsWaiting)
            {
                if (waitingPlayers.Count > 0)
                {
                    IPlayer firstWaitingPlayer = waitingPlayers[0];
                    waitingPlayers.Remove(firstWaitingPlayer);
                    player.StartWaiting();
                    waitingPlayers.Add(player);
                    firstWaitingPlayer.StopWaiting();
                }
                else
                {
                    player.StartWaiting();
                    waitingPlayers.Add(player);
                }
            }
        }
    }
}