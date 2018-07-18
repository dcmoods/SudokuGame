using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku.ApplicationLayer.Models;

namespace SudokuClient.Tests
{
    [TestClass]
    public class ApplicationLayerTests
    {
        [TestMethod]
        public void ShouldInitializeAGameBoardWithPuzzleArray()
        {
            var gameBoard = new GameBoard();
            Assert.IsInstanceOfType(gameBoard, typeof(GameBoard));
            Assert.AreEqual(81, gameBoard.PuzzleArray.Length);
        }

        [TestMethod]
        public void ShouldInitializeAGameBoardWithPuzzleArrayParam()
        {
            int[,] array = new int[9, 9];
            var gameBoard = new GameBoard(array);
            Assert.IsInstanceOfType(gameBoard, typeof(GameBoard));
            Assert.AreEqual(81, gameBoard.PuzzleArray.Length);
        }

        [TestMethod]
        public void ShouldGetGameBoardCell00Value()
        {
            int[,] array = new int[9, 9];
            var gameBoard = new GameBoard(array);
            Assert.IsInstanceOfType(gameBoard, typeof(GameBoard));
            Assert.AreEqual(0, gameBoard.Cell00);
        }
    }
}
