using GameOfGoose.GameObjects;
using GameOfGoose.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;

namespace GameOfGoose.Tests
{
    public class GameOfGooseMovementTests
    {
        private ITestOutputHelper output;
        private GameBoard board;
        private List<IPlayer> playerList;
        private Dice dice;
        private Processor processor;
        private Mock<ILogger> logger = new Mock<ILogger>();

        public GameOfGooseMovementTests(ITestOutputHelper output)
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
        public void PiecesCanMove()
        {
            // Arrange

            var player = playerList.First();
            player.Position = 0;
            int diceRoll = dice.Roll();

            // Act

            player.Position += diceRoll;

            // Assert

            Assert.Equal(diceRoll, player.Position);
        }

        [Fact]
        public void PlayerFirstRollIsSixAndThree()
        {
            // Arrange

            var player = playerList.First();

            // Act

            processor.ProcessPlayerTurn(6, 3, 1, player);

            // Assert

            Assert.Equal(53, player.Position);
            output.WriteLine("Player lands on Square 53, if first thhrow was 6 and 3");
        }

        [Fact]
        public void PlayerFirstRollIsFiveAndFour()
        {
            // Arrange

            var player = playerList.First();

            // Act

            processor.ProcessPlayerTurn(5, 4, 1, player);

            // Assert

            Assert.Equal(26, player.Position);
            output.WriteLine("Player lands on Square 26, if first thhrow was 5 and 4");
        }

        [Fact]
        public void IfPlayerOvershootsEndGetsSendBack()
        {
            // Arrange
            var player = playerList.First();
            player.Position = 62;
            int diceThrow = 4;
            // Act

            player.Move(diceThrow);

            // Assert

            Assert.Equal(60, player.Position);
        }

        [Fact]
        public void GooseSquaresAddTheDiceThrowAndHandlesEndOfBoard()
        {
            // Arrange
            
            var player = playerList.First();
            player.Position = 51;

            // Act

            processor.ProcessPlayerTurn(3,5,1, player);

            // Assert

            Assert.Equal(51, player.Position);
            output.WriteLine("player starts on 51 lands on 59 (goose) goes past 63 and returns to 59 (goose) and keeps going backward to 51");
        }

        [Fact]
        public void GooseSquaresAddTheDiceThrow()
        {
            // Arrange

            var player = playerList.First();
            player.Position = 0;

            // Act

            processor.ProcessPlayerTurn(3, 2, 1, player);

            // Assert

            Assert.Equal(10, player.Position);
            output.WriteLine("player starts on 0 lands on 5 (goose) goes to 10");
        }

        [Fact]
        public void CheckIfOvershootWorksCorrectly()
        {
            // Arrange

            var mockLogger = new Mock<ILogger>();
            var player1 = playerList[0];
            var processor = new Processor(mockLogger.Object);
            processor.Board = board;
            processor.players.Add(player1);
            processor.players[0].Position = 60;

            // Act

            processor.ProcessPlayerTurn(3, 2, 1, player1);
            output.WriteLine("player position  " + player1.Position);

            // Assert

            Assert.Equal(61, player1.Position);
            output.WriteLine("Overshoots works with the actual game.");
        }
    }
}