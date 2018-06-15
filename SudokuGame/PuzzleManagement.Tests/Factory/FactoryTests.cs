using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PuzzleManagement.Core.Factories;
using PuzzleManagement.Core.Models;

namespace PuzzleManagement.Tests.Factory
{
    [TestClass]
    public class FactoryTests
    {
        [TestMethod]
        public void ReturnEmptyPuzzleByDefault()
        {
            var puzzle = PuzzleFactory.GetPuzzle(Core.Enums.Difficulty.Empty);
            Assert.IsInstanceOfType(puzzle, typeof(EmptyPuzzle));
        }

        [TestMethod]
        public void ReturnsEasyPuzzle()
        {
            var puzzle = PuzzleFactory.GetPuzzle(Core.Enums.Difficulty.Easy);
            Assert.IsInstanceOfType(puzzle, typeof(EasyPuzzle));
        }

        [TestMethod]
        public void ReturnsMediumPuzzle()
        {
            var puzzle = PuzzleFactory.GetPuzzle(Core.Enums.Difficulty.Medium);
            Assert.IsInstanceOfType(puzzle, typeof(MediumPuzzle));
        }

        [TestMethod]
        public void ReturnsHardPuzzle()
        {
            var puzzle = PuzzleFactory.GetPuzzle(Core.Enums.Difficulty.Hard);
            Assert.IsInstanceOfType(puzzle, typeof(HardPuzzle));
        }
    }
}
