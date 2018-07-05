using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleManagement.Core.Models
{
    public class PuzzleEntity
    {
        public Guid Id { get; set; }
        public int Difficulty { get; set; }
        public TimeSpan TimeElapsed { get; set; }
        public virtual IEnumerable<ArrayEntity> WorkingPuzzleArray { get; set; }
        public virtual IEnumerable<ArrayEntity> SolvedPuzzleArray { get; set; }

    }
}
