using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PuzzleManagement.Core.Factories;
using PuzzleManagement.Core.Models;
using PuzzleManagement.Persistence;
using PuzzleManagement.Persistence.Mapping;

namespace PuzzleManagement.Tests.Persistence
{
    [TestClass]
    public class PersistenceTests
    {

        [TestMethod]
        public void MapPuzzleToPuzzleEntity()
        {
            var puzzle = PuzzleFactory.GetPuzzle(Core.Enums.Difficulty.Medium);
            Assert.IsInstanceOfType(puzzle, typeof(MediumPuzzle));
            puzzle.CreatePuzzle();
            Assert.IsNotNull(puzzle.PuzzleArray);
            var dataMapper = new PuzzleMapper();
            var puzzleEntity = dataMapper.MapPuzzleToPuzzleEntity(puzzle);

            Assert.AreEqual(puzzle.Id, puzzleEntity.Id);
        }

        [TestMethod]
        public void MapPuzzleEntityToPuzzle()
        {
            var puzzle = PuzzleFactory.GetPuzzle(Core.Enums.Difficulty.Medium);
            Assert.IsInstanceOfType(puzzle, typeof(MediumPuzzle));

            puzzle.CreatePuzzle();
            Assert.IsNotNull(puzzle.PuzzleArray);

            var dataMapper = new PuzzleMapper();
            var puzzleEntity = dataMapper.MapPuzzleToPuzzleEntity(puzzle);
            Assert.AreEqual(puzzle.Id, puzzleEntity.Id);

            var puzzleMapBack = dataMapper.MapPuzzleEntityToPuzzle(puzzleEntity);
            Assert.AreEqual(puzzleEntity.Id, puzzleMapBack.Id);
        }

        [TestMethod]
        public void ShouldStorePuzzleEntityMappedFromPuzzle()
        {
            using (var context = new GameContext())
            {
                var puzzle = PuzzleFactory.GetPuzzle(Core.Enums.Difficulty.Medium);
                Assert.IsInstanceOfType(puzzle, typeof(MediumPuzzle));

                puzzle.CreatePuzzle();
                Assert.IsNotNull(puzzle.PuzzleArray);

                var dataMapper = new PuzzleMapper();
                var puzzleEntity = dataMapper.MapPuzzleToPuzzleEntity(puzzle);
                puzzleEntity.Name = "test save";
                Assert.AreEqual(puzzle.Id, puzzleEntity.Id);

                context.PuzzleEntities.Add(puzzleEntity);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void ShouldLoadPuzzleEntities()
        {
            var gameRepo = new GameRepository(new PuzzleMapper());
            var puzzleEntities = gameRepo.GetPuzzleList();
            Assert.IsTrue(puzzleEntities.Count > 0);
        }

        [TestMethod]
        public void ShouldGetPuzzleEntityAndReturnPuzzleFromRepo()
        {
            var gameRepo = new GameRepository(new PuzzleMapper());
            var puzzleList = gameRepo.GetPuzzleList();
            Assert.IsNotNull(puzzleList);
            var puzzle = gameRepo.GetPuzzleById(puzzleList.Last().Id);
            Assert.IsNotNull(puzzle);
        }

        [TestMethod]
        public void ShouldSavePuzzle()
        {

            var gameRepo = new GameRepository(new PuzzleMapper());
            var puzzleEntities = gameRepo.GetPuzzleList();
            Assert.IsNotNull(puzzleEntities);
            var originalPuzzleCount = puzzleEntities.Count;

            var puzzle = PuzzleFactory.GetPuzzle(Core.Enums.Difficulty.Medium);
            Assert.IsInstanceOfType(puzzle, typeof(MediumPuzzle));
            puzzle.CreatePuzzle();
            Assert.IsNotNull(puzzle.PuzzleArray);            
            
            gameRepo.SaveGame(puzzle);
            puzzleEntities = gameRepo.GetPuzzleList();
            Assert.IsNotNull(puzzleEntities);
            Assert.AreNotEqual(originalPuzzleCount, puzzleEntities.Count);
        }

        [TestMethod]
        public void ShouldDeletePuzzle()
        {
            var gameRepo = new GameRepository(new PuzzleMapper());
            var puzzleEntities = gameRepo.GetPuzzleList();
            Assert.IsNotNull(puzzleEntities);

            var originalPuzzleCount = puzzleEntities.Count;
            var puzzle = gameRepo.GetPuzzleById(puzzleEntities.Last().Id);
            puzzle.State = Core.Enums.ObjectState.Deleted;
            gameRepo.DeletePuzzle(puzzle);

            puzzleEntities = gameRepo.GetPuzzleList();
            Assert.IsNotNull(puzzleEntities);
            Assert.AreNotEqual(originalPuzzleCount, puzzleEntities.Count);
        }
    }
}
