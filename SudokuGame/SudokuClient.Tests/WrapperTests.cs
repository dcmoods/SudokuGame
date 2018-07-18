using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku.ApplicationLayer.Models;
using Sudoku.Client.Wrapper;

namespace SudokuClient.Tests
{
    [TestClass]
    public class WrapperTests
    {
        [TestMethod]
        public void ShouldWrapGameBoardModel()
        {
            var gameBoardWrapper = new GameBoardWrapper(new GameBoard());
            Assert.IsInstanceOfType(gameBoardWrapper, typeof(GameBoardWrapper));
        }
    }
}
