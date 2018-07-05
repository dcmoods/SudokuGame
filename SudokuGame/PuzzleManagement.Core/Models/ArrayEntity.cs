using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleManagement.Core.Models
{
    public class ArrayEntity
    {
        public Guid Id { get; set; }
        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }
        public int Value { get; set; }
    }
}
