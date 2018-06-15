using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleManagement.Core.Models
{
    public class EasyPuzzle : Puzzle
    {
        public EasyPuzzle() : base()
        {
            Difficulty = Enums.Difficulty.Easy;
            Generator = Generator.Create(this.Difficulty);
        }

        public override void CreatePuzzle()
        {
            PuzzleArray = Generator.Generate();
        }
    }
}
