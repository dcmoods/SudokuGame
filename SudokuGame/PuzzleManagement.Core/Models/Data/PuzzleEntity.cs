using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleManagement.Core.Models
{
    public class PuzzleEntity
    {
        public PuzzleEntity()
        {
            WorkingPuzzleArray = new List<ArrayEntity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Difficulty { get; set; }
        public int TimeElapsed { get; set; }
        public string LastSave { get; set; }
        public virtual List<ArrayEntity> WorkingPuzzleArray { get; set; }
    }
}
