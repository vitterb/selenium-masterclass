using GameOfGoose.GameObjects;
using GameOfGoose.GameObjects.Squares;
using GameOfGoose.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;

namespace GameOfGoose.Tests
{
    public class GameOfGooseBoardTests
    {
        private ITestOutputHelper output;
        private GameBoard board;
        private Mock<ILogger> logger = new Mock<ILogger>();

        public GameOfGooseBoardTests(ITestOutputHelper output)
        {
            this.output = output;
            board = GameBoard.GetInstance();
        }

        [Fact]
        public void GameBoardInitialSetup()
        {
            // Arrange

            // Act

            int numberOfSquares = board.Squares.Count;

            // Assert

            Assert.Equal(64, numberOfSquares);
            output.WriteLine("If passed Board has 63 squares and start (or 0)");
        }

        [Fact]
        public void GameBoardGooseSquaresCreated()
        {
            // arrange

            var goosesquarenumbers = new List<int>() { 5, 9, 14, 18, 23, 27, 32, 36, 41, 45, 50, 54, 59 };

            // act

            var goosesquares = board.Squares.OfType<GooseSquare>().ToList();

            // assert

            foreach (int goosesquarenumber in goosesquarenumbers)
            {
                Assert.Contains(goosesquares, square => square.Number == goosesquarenumber);
            }
            output.WriteLine("if passed all 13 goose squares are created.");
        }

        [Fact]
        public void GameBoardBridgeSquareCreated()
        {
            // Arrange

            int bridgeSquareNumber = 6;

            // Act

            var BridgeSquare = board.Squares.OfType<BridgeSquare>().ToList();

            // Assert

            Assert.Contains(BridgeSquare, square => square.Number == bridgeSquareNumber);
            output.WriteLine("Bridge is created on index number 6 in the list.");
        }

        [Fact]
        public void GameBoardInnSquareCreated()
        {
            // Arrange

            int InnSquareNumber = 19;

            // Act

            var InnSquare = board.Squares.OfType<InnSquare>().ToList();

            // Assert

            Assert.Contains(InnSquare, square => square.Number == InnSquareNumber);
            output.WriteLine("Inn is created on index number 19 in the list");
        }

        [Fact]
        public void GameBoardWellSquareCreated()
        {
            // Arrange

            int WellSquareNumber = 31;

            // Act

            var WellSquare = board.Squares.OfType<WellSquare>().ToList();

            // Assert

            Assert.Contains(WellSquare, square => square.Number == WellSquareNumber);
            output.WriteLine("Well is ceeated on index number 31 in the list");
        }

        [Fact]
        public void GameBoardMazeSquareCreated()
        {
            // Arrange

            int MazeNumber = 42;

            // Act

            var MazeSquare = board.Squares.OfType<MazeSquare>().ToList();

            // Assert

            Assert.Contains(MazeSquare, square => square.Number == MazeNumber);
            output.WriteLine("Maze is created on index 42 in the list");
        }

        [Fact]
        public void GameBoardPrisonSquareCreated()
        {
            // Arrange

            int PrisonNumber = 52;

            // Act

            var PrisonSquare = board.Squares.OfType<PrisonSquare>().ToList();

            // Assert

            Assert.Contains(PrisonSquare, square => square.Number == PrisonNumber);
            output.WriteLine("Prison is created on index 52 in the list");
        }

        [Fact]
        public void GameBoardDeathSquareCreated()
        {
            // Arrange

            int DeathNumber = 58;

            // Act

            var DeathSquare = board.Squares.OfType<DeathSquare>().ToList();

            // Assert

            Assert.Contains(DeathSquare, square => square.Number == DeathNumber);
            output.WriteLine("Death is created on index 58 in the list");
        }

        [Fact]
        public void GameBoardEndSquareCreated()
        {
            // Arrange

            int EndNumber = 63;

            // Act

            var EndSquare = board.Squares.OfType<EndSquare>().ToList();

            // Assert

            Assert.Contains(EndSquare, square => square.Number == EndNumber);
            output.WriteLine("End is created on index 63 in the list");
        }
    }
}