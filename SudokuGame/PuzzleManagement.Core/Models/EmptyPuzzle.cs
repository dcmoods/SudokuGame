using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleManagement.Core.Models
{
    public class EmptyPuzzle : Puzzle
    {
        public EmptyPuzzle() : base()
        {
            Difficulty = Enums.Difficulty.Empty;
            Generator = Generator.Create(this.Difficulty);
        }

        public override void CreatePuzzle()
        {
            PuzzleArray = Generator.Generate();
        }

    }
}
