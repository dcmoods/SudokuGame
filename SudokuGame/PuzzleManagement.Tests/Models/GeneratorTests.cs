using Microsoft.VisualStudio.TestTools.UnitTesting;
using PuzzleManagement.Core.Enums;
using PuzzleManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleManagement.Core.Models.Tests
{
    [TestClass()]
    public class GeneratorTests
    {
        [TestMethod()]
        public void CreateTest()
        {
            var generator = Generator.Create(Difficulty.Easy);
            Assert.IsInstanceOfType(generator, typeof(Generator));
        }

        [TestMethod()]
        public void GenerateTest()
        {
            var generator = Generator.Create(Difficulty.Empty);
            Assert.IsInstanceOfType(generator, typeof(Generator));
            var puzzle = generator.Generate();
            Assert.IsNotNull(puzzle);
            Assert.IsInstanceOfType(puzzle, typeof(int[,]));

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                    System.Diagnostics.Debug.Write(puzzle[row,col]);
                System.Diagnostics.Debug.WriteLine("");
            }
        }
    }
}