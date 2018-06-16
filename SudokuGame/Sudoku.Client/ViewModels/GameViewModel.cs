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
            Init();
        }

        private void Init()
        {
            Difficulty = Difficulty.Medium;
            Puzzle = PuzzleFactory.GetPuzzle(Difficulty);
            Puzzle.CreatePuzzle();
            GameBoard = new GameBoardWrapper(new GameBoard(Puzzle.PuzzleArray));
        }

        GameBoardWrapper gameBoard;
        public GameBoardWrapper GameBoard
        {
            get { return gameBoard; }
            set { SetProperty(ref gameBoard, value); }
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
            MapToArrayEntity(Puzzle.PuzzleArray);
        }


        public List<SudokuCell> MapToArrayEntity(int[,] array)
        {
            List<SudokuCell> cellList = new List<SudokuCell>();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    SudokuCell cellEntity = new SudokuCell()
                    {
                        RowIndex = i,
                        ColumnIndex = j,
                        Value = array[i, j]
                    };
                    cellList.Add(cellEntity);
                }
            }
            return cellList;
        }
    }


}