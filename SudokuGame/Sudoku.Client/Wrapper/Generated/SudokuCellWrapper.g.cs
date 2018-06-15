using System;
using System.Linq;
using Sudoku.ApplicationLayer.Models;

namespace Sudoku.Client.Wrapper
{
	public partial class SudokuCellWrapper : ModelWrapper<SudokuCell>
	{	
		public SudokuCellWrapper(SudokuCell model ) : base (model)
		{
			
		}


		public System.Int32 Value
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 ValueOriginalValue => GetOriginalValue<System.Int32>(nameof(Value));

		public bool ValueIsChanged => GetIsChanged(nameof(Value));

		public System.Int32 RowIndex
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 RowIndexOriginalValue => GetOriginalValue<System.Int32>(nameof(RowIndex));

		public bool RowIndexIsChanged => GetIsChanged(nameof(RowIndex));

		public System.Int32 ColumnIndex
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 ColumnIndexOriginalValue => GetOriginalValue<System.Int32>(nameof(ColumnIndex));

		public bool ColumnIndexIsChanged => GetIsChanged(nameof(ColumnIndex));
	}	
}
