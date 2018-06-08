using Microsoft.VisualStudio.TestTools.UnitTesting;
using PuzzleManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleManagement.Core.Models.Tests
{
    [TestClass()]
    public class SolverTests
    {
        [TestMethod()]
        public void CreateTest()
        {
            Solver solver = Solver.Create();
            Assert.IsNotNull(solver);
            Assert.IsInstanceOfType(solver, typeof(Solver));
        }

        [TestMethod()]
        public void SolveTest()
        {
            int[,] puzzle = new int[,]
            {
                {3, 0, 6, 5, 0, 8, 4, 0, 0},
                {5, 2, 0, 0, 0, 0, 0, 0, 0},
                {0, 8, 7, 0, 0, 0, 0, 3, 1},
                {0, 0, 3, 0, 1, 0, 0, 8, 0},
                {9, 0, 0, 8, 6, 3, 0, 0, 5},
                {0, 5, 0, 0, 9, 0, 6, 0, 0},
                {1, 3, 0, 0, 0, 0, 2, 5, 0},
                {0, 0, 0, 0, 0, 0, 0, 7, 4},
                {0, 0, 5, 2, 0, 6, 3, 0, 0}
            };

            Solver solver = Solver.Create();
            bool result = solver.Solve(puzzle);
            Assert.IsTrue(result);
        }
    }
}