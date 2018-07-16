using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sudoku.Client.Wrapper
{
    public partial class GameBoardWrapper
    {
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            for(int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (PuzzleArray[i, j] > 9 || PuzzleArray[i, j] < 0)
                        yield return new ValidationResult("value must be between 1 and 9.", new[] { $"Cell{i}{j}" });
                }
            }
        }
    }
}
