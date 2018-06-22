using PuzzleManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleManagement.Core.Models
{
    public abstract class Puzzle
    {
        public Puzzle()
        {
            Solver = Solver.Create();
            StartTime = DateTime.Now;
        }

        public Guid Id { get; set; }
        protected Solver Solver { get; set; }
        protected Generator Generator { get; set; }
        protected Difficulty Difficulty { get; set; }
        public int[,] PuzzleArray { get; set; }
        public int[,] SolvedPuzzleArray { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public abstract void CreatePuzzle();

        public bool Solve()
        {
            Contract.Requires(PuzzleArray != null);

            SolvedPuzzleArray = (int[,])PuzzleArray.Clone();
            var result = Solver.Solve(SolvedPuzzleArray);
            SolvedPuzzleArray = Solver.SolvedPuzzle;
            return result;
        }

        public bool Check()
        {
            if (SolvedPuzzleArray == null)
            {
                Solve();
            }
            return PuzzlesAreEqual();
        }

        public bool PuzzlesAreEqual()
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (SolvedPuzzleArray[row,col] != PuzzleArray[row,col])
                        return false;
                }
            }
            return true;
        }
    }
}
