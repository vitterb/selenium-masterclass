using GameOfGoose.GameObjects;
using GameOfGoose.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;

namespace GameOfGoose.Tests
{
    public class GameOfGoosePlayerSquareActionsTests
    {
        private ITestOutputHelper output;
        private GameBoard board;
        private List<IPlayer> playerList;
        private Dice dice;
        private Processor processor;
        private Mock<ILogger> logger = new Mock<ILogger>();

        public GameOfGoosePlayerSquareActionsTests(ITestOutputHelper output)
        {
            this.output = output;

            board = GameBoard.GetInstance();
            playerList = new List<IPlayer>
            {
                new Player("player1"),
                new Player("player2")
            };
            dice = new Dice();
            processor = new Processor(logger.Object);
        }

        [Fact]
        public void PlayerLandsOnBridge()
        {
            // Arrange

            var player = playerList.First();
            player.Position = 6;
            var Square = board.GetSquare(player.Position);

            // Act
            Square.Action(player);

            // Assert
            Assert.Equal(12, player.Position);
            output.WriteLine("If player lands on bridge, position is set to 12");
        }

        [Fact]
        public void PlayerLandsOnInn()
        {
            // Arrange

            var player = playerList.First();
            player.Position = 19;
            var Square = board.GetSquare(player.Position);

            //Act
            Square.Action(player);

            Assert.Equal(1, player.SkipCounter);
            output.WriteLine("player SkipCounter = 1");
        }

        [Fact]
        public void PlayerLandsOnMaze()
        {
            // Arrange
            var player = playerList.First();
            player.Position = 42;
            var Square = board.GetSquare(player.Position);

            // Act
            Square.Action(player);

            // Assert

            Assert.Equal(39, player.Position);
            output.WriteLine("Player lands on maze and goes to 39.");
        }

        [Fact]
        public void PlayerLandsOnPrison()
        {
            // Arrange
            var player = playerList.First();
            player.Position = 52;
            var Square = board.GetSquare(player.Position);

            // Act
            Square.Action(player);

            // Assert

            Assert.Equal(3, player.SkipCounter);
            output.WriteLine("Player bool skipThreeTurns is set to true");
        }

        [Fact]
        public void PlayerLandsOnDeath()
        {
            // Arrange
            var player = playerList.First();
            player.Position = 58;
            var Square = board.GetSquare(player.Position);

            // Act
            Square.Action(player);

            // Assert

            Assert.Equal(0, player.Position);
            output.WriteLine("Player lands on Death and goes to start (0).");
        }

        [Fact]
        public void PlayerLandsOnEnd()
        {
            // Arrange
            var player = playerList.First();
            player.Position = 63;
            var Square = board.GetSquare(player.Position);

            // Act
            Square.Action(player);

            // Assert

            Assert.True(player.GameOver);
            output.WriteLine("Player lands on end and game ends.");
            output.WriteLine((player.GameOver).ToString());
        }

        [Fact]
        public void PlayerLandsOnWell_NoOtherPlayers()
        {
            // Arrange
            var player = playerList.First();
            player.Position = 31;
            var Square = board.GetSquare(player.Position);

            // Act
            Square.Action(player);

            // Assert

            Assert.True(player.IsWaiting);
            output.WriteLine("Player lands on well with no other players and starts waiting");
        }

        [Fact]
        public void PlayerLandsOnWell_OtherPlayers()
        {
            // Arrange
            var player = playerList.First();
            var player2 = playerList[1];
            player.Position = 31;
            var Square = board.GetSquare(player.Position);
            player2.Position = 31;
            var Square2 = board.GetSquare(player.Position);

            // Act
            Square.Action(player);
            Square2.Action(player2);
            // Assert

            Assert.False(player.IsWaiting);
            Assert.True(player2.IsWaiting);
            output.WriteLine("Player lands on well with no other players and starts waiting");
        }

        [Fact]
        public void PlayerInWellKeepsWaitingUntilOtherPlayerLandsOnSquare()
        {
            // Arrange

            var mockLogger = new Mock<ILogger>();
            var player1 = playerList[0];
            var player2 = playerList[1];
            var processor = new Processor(mockLogger.Object);
            processor.Board = board;
            processor.players.Add(player1);
            processor.players.Add(player2);
            processor.players[0].Position = 27;
            processor.players[1].Position = 24;

            // Act

            processor.ProcessPlayerTurn(2, 2, 1, player1);
            output.WriteLine("player 1 " + player1.Position + " " + player1.IsWaiting.ToString());

            processor.ProcessPlayerTurn(1, 1, 2, player2);
            output.WriteLine("player 2 " + player2.Position + " " + player2.IsWaiting.ToString());

            processor.ProcessPlayerTurn(2, 1, 3, player1);
            output.WriteLine("player 1 " + player1.Position + " " + player1.IsWaiting.ToString());

            processor.ProcessPlayerTurn(2, 1, 4, player2);
            output.WriteLine("player 2 " + player2.Position + " " + player2.IsWaiting.ToString());

            processor.ProcessPlayerTurn(2, 2, 5, player1);
            output.WriteLine("player 1 " + player1.Position + " " + player1.IsWaiting.ToString());

            processor.ProcessPlayerTurn(1, 1, 6, player2);
            output.WriteLine("player 2 " + player2.Position + " " + player2.IsWaiting.ToString());

            processor.ProcessPlayerTurn(1, 1, 7, player1);
            output.WriteLine("player 1 " + player1.Position + " " + player1.IsWaiting.ToString());

            processor.ProcessPlayerTurn(2, 2, 8, player2);
            output.WriteLine("player 2 " + player2.Position + " " + player2.IsWaiting.ToString());

            processor.ProcessPlayerTurn(1, 1, 7, player1);
            output.WriteLine("player 1 " + player1.Position + " " + player1.IsWaiting.ToString());

            processor.ProcessPlayerTurn(2, 2, 8, player2);
            output.WriteLine("player 2 " + player2.Position + " " + player2.IsWaiting.ToString());

            // Assert

            Assert.Equal(35, player1.Position);
            Assert.Equal(31, player2.Position);
            output.WriteLine("Player waits untill other player enters well");
        }

        [Fact]
        public void CheckIfPrisonWorksCorrectly()
        {
            // Arrange

            var mockLogger = new Mock<ILogger>();
            var player1 = playerList[0];
            var player2 = playerList[1];
            var processor = new Processor(mockLogger.Object);
            processor.Board = board;
            processor.players.Add(player1);
            processor.players[0].Position = 50;

            // Act

            processor.ProcessPlayerTurn(1, 1, 1, player1);
            output.WriteLine("player 1 " + player1.Position + " " + player1.SkipCounter.ToString() + " " + player1.IsPrisoner);
            processor.ProcessPlayerTurn(1, 1, 1, player1);
            output.WriteLine("player 1 " + player1.Position + " " + player1.SkipCounter.ToString() + " " + player1.IsPrisoner);
            processor.ProcessPlayerTurn(1, 1, 1, player1);
            output.WriteLine("player 1 " + player1.Position + " " + player1.SkipCounter.ToString() + " " + player1.IsPrisoner);
            processor.ProcessPlayerTurn(1, 1, 1, player1);
            output.WriteLine("player 1 " + player1.Position + " " + player1.SkipCounter.ToString() + " " + player1.IsPrisoner);
            processor.ProcessPlayerTurn(2, 2, 1, player1);
            output.WriteLine("player 1 " + player1.Position + " " + player1.SkipCounter.ToString() + " " + player1.IsPrisoner);

            // Assert

            Assert.Equal(56, player1.Position);
            output.WriteLine("player waits 3 turns on prison");
        }

        [Fact]
        public void CheckIfInnWorksCorrectly()
        {
            // Arrange

            var mockLogger = new Mock<ILogger>();
            var player1 = playerList[0];
            var processor = new Processor(mockLogger.Object);
            processor.Board = board;
            processor.players.Add(player1);
            processor.players[0].Position = 17;

            // Act

            processor.ProcessPlayerTurn(1, 1, 1, player1);
            output.WriteLine("player 1 " + player1.Position + " " + player1.SkipCounter.ToString() + " " + player1.IsVisitingInn);
            processor.ProcessPlayerTurn(1, 1, 1, player1);
            output.WriteLine("player 1 " + player1.Position + " " + player1.SkipCounter.ToString() + " " + player1.IsVisitingInn);
            processor.ProcessPlayerTurn(1, 1, 1, player1);
            output.WriteLine("player 1 " + player1.Position + " " + player1.SkipCounter.ToString() + " " + player1.IsVisitingInn);

            // Assert

            Assert.Equal(21, player1.Position);
            output.WriteLine("player waits 1 turns on Inn");
        }
    }
}