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
            var dataMapper = new DataMappingFactory();
            var puzzleEntity = dataMapper.MapPuzzleToPuzzleEntity(puzzle);

            Assert.AreEqual(puzzle.Id.ToString(), puzzleEntity.Id);
        }

        [TestMethod]
        public void MapPuzzleEntityToPuzzle()
        {
            var puzzle = PuzzleFactory.GetPuzzle(Core.Enums.Difficulty.Medium);
            Assert.IsInstanceOfType(puzzle, typeof(MediumPuzzle));

            puzzle.CreatePuzzle();
            Assert.IsNotNull(puzzle.PuzzleArray);

            var dataMapper = new DataMappingFactory();
            var puzzleEntity = dataMapper.MapPuzzleToPuzzleEntity(puzzle);
            Assert.AreEqual(puzzle.Id.ToString(), puzzleEntity.Id);

            var puzzleMapBack = dataMapper.MapPuzzleEntityToPuzzle(puzzleEntity);
            Assert.AreEqual(puzzleEntity.Id, puzzleMapBack.Id.ToString());
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

                var dataMapper = new DataMappingFactory();
                var puzzleEntity = dataMapper.MapPuzzleToPuzzleEntity(puzzle);
                puzzleEntity.Name = "test save";
                Assert.AreEqual(puzzle.Id.ToString(), puzzleEntity.Id);

                context.PuzzleEntities.Add(puzzleEntity);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void ShouldLoadPuzzleFromPuzzleEntityStore()
        {
            //using (var context = new GameContext())
            //{
            //    var puzzleEntity = context.PuzzleEntities.SingleOrDefault(p => p.Id == "09679014-0c9a-4980-906f-58a299fe7273");
            //    Assert.IsNotNull(puzzleEntity);

            //    var dataMapper = new DataMappingFactory();
            //    var puzzle = dataMapper.MapPuzzleEntityToPuzzle(puzzleEntity);
            //    Assert.AreEqual(puzzleEntity.Id, puzzle.Id.ToString());
            //}
        }
    }
}
