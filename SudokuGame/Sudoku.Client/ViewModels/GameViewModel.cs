using Prism.Commands;
using PuzzleManagement.Core.Enums;
using PuzzleManagement.Core.Factories;
using PuzzleManagement.Core.Models;
using Sudoku.ApplicationLayer.Models;
using Sudoku.Client.Commands;
using Sudoku.Client.Common;
using Sudoku.Client.Wrapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Client.ViewModels
{
    public class GameViewModel : ViewModel
    {

        public GameViewModel()
        {
            New = new Command(NewCommand);
            New.Execute(true);

            SudokuCells.CollectionChanged += SudokuCells_CollectionChanged;
        }

        private void SudokuCells_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if(e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach(SudokuCellWrapper item in e.OldItems)
                {
                    item.PropertyChanged += Item_PropertyChanged;
                }
            }
        }

        private void Item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SudokuCellWrapper.Value))
            {

            }
        }

        ObservableCollection<SudokuCellWrapper> sudokuCells;
        ObservableCollection<SudokuCellWrapper> SudokuCells
        {
            get { return sudokuCells; }
            set { SetProperty(ref sudokuCells, value); }
        }

        Puzzle puzzle;
        public Puzzle Puzzle
        {
            get
            {
                return puzzle;
            }
            set
            {
                SetProperty(ref puzzle, value);
            }
        }

        public Difficulty Difficulty { get; set; }

        public Command New { get; private set; }

        private void NewCommand()
        {
            Puzzle = PuzzleFactory.GetPuzzle(Difficulty);
            Puzzle.CreatePuzzle();
            SudokuCells = new ObservableCollection<SudokuCellWrapper>(MapToArrayEntity(Puzzle.PuzzleArray));
        }

        public static List<SudokuCellWrapper> MapToArrayEntity(int[,] array)
        {
            List<SudokuCellWrapper> arrayEntities = new List<SudokuCellWrapper>();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    SudokuCellWrapper arrayEntity = new SudokuCellWrapper(new SudokuCell()
                    {
                        RowIndex = i,
                        ColumnIndex = j,
                        Value = array[i, j]
                    });
                    arrayEntities.Add(arrayEntity);
                }
            }
            return arrayEntities;
        }
    }

    

}
