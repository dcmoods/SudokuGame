using PuzzleManagement.Core.Enums;
using PuzzleManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleManagement.Core.Factories
{
    public class PuzzleFactory
    {
        public static Puzzle GetPuzzle(Difficulty difficulty)
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    return new EasyPuzzle();
                case Difficulty.Medium:
                    return new MediumPuzzle();
                case Difficulty.Hard:
                    return new HardPuzzle();
                default:
                    return new EmptyPuzzle();
            }
        }
    }
}
