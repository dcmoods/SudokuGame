using System;
using System.Linq;
using Sudoku.ApplicationLayer.Models;

namespace Sudoku.Client.Wrapper
{
	public partial class GameBoardWrapper : ModelWrapper<GameBoard>
	{	
		public GameBoardWrapper(GameBoard model ) : base (model)
		{
			
		}

		public ChangeTrackingCollection<SudokuCellWrapper> SudokuCells { get; private set; }

		protected override void InitializeCollectionProperties(GameBoard model)
		{
			if (model.SudokuCells == null)
			{
				throw new ArgumentException("SudokuCells cannot be null");
			}
 
			SudokuCells = new ChangeTrackingCollection<SudokuCellWrapper>(
			model.SudokuCells.Select(e => new SudokuCellWrapper(e)));
			RegisterCollection(SudokuCells, model.SudokuCells);
		}
	}	
}
