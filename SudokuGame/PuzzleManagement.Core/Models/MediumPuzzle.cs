using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleManagement.Core.Models
{
    public class MediumPuzzle : Puzzle
    {
        public MediumPuzzle() : base()
        {
            Difficulty = Enums.Difficulty.Medium;
            Generator = Generator.Create(this.Difficulty);
        }

        public override void CreatePuzzle()
        {
            PuzzleArray = Generator.Generate();
        }
    }
}
