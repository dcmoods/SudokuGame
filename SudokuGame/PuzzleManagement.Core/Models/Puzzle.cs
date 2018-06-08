using PuzzleManagement.Core.Enums;
using System;
using System.Collections.Generic;
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
        }

        public Guid Id { get; set; }
        protected Solver Solver { get; set; }
        protected Generator Generator { get; set; }
        protected Difficulty Difficulty { get; set; }
        protected int[,] PuzzleArray { get; set; }
        protected int[,] SolvedPuzzleArray { get; set; }
        protected DateTime StartTime { get; set; }
        protected DateTime EndTime { get; set; }

        protected abstract void Create();
        protected abstract bool Solve();
        protected abstract bool Check();
        protected abstract bool PuzzlesAreEqual();
    }
}
