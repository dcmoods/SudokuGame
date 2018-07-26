using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prism.Events;
using PuzzleManagement.Persistence;
using Sudoku.Client.ViewModels;
using PuzzleManagement.Persistence.Mapping;
using PuzzleManagement.Core.Enums;

namespace SudokuClient.Tests
{
    [TestClass]
    public class ViewModelTests
    {
        private Mock<EventAggregator> _mockEventAggregator;
        private Mock<GameRepository> _mockGameRepository;

        public ViewModelTests()
        {
            _mockEventAggregator = new Mock<EventAggregator>();
            _mockGameRepository = new Mock<GameRepository>(new PuzzleMapper());
        }

        [TestMethod]
        public void ShouldCreateAGameViewModel()
        {
            var gameViewModel = new GameViewModel(
                _mockEventAggregator.Object, _mockGameRepository.Object);

            Assert.IsInstanceOfType(gameViewModel, typeof(GameViewModel));
            Assert.AreEqual(Difficulty.Empty, gameViewModel.Difficulty);
        }

        [TestMethod]
        public void GameViewModelShouldLoadPuzzle()
        {
            var gameViewModel = new GameViewModel(
                _mockEventAggregator.Object, _mockGameRepository.Object);

            Assert.IsInstanceOfType(gameViewModel, typeof(GameViewModel));
            Assert.IsNull(gameViewModel.GameBoard);

            gameViewModel.LoadPuzzle().GetAwaiter().GetResult();
            Assert.IsNotNull(gameViewModel.GameBoard);
        }

        [TestMethod]
        public void GameViewModelShouldUpdateDifficulty()
        {
            var gameViewModel = new GameViewModel(
                _mockEventAggregator.Object, _mockGameRepository.Object);

            Assert.IsInstanceOfType(gameViewModel, typeof(GameViewModel));
            Assert.AreEqual(Difficulty.Empty, gameViewModel.Difficulty);

            gameViewModel.Difficulty = Difficulty.Hard;
            Assert.AreEqual(Difficulty.Hard, gameViewModel.Difficulty);
        }

    }
}
