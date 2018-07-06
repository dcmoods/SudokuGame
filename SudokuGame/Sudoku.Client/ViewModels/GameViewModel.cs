using PuzzleManagement.Core.Enums;
using PuzzleManagement.Core.Factories;
using PuzzleManagement.Core.Models;
using PuzzleManagement.Persistence;
using Sudoku.ApplicationLayer.Models;
using Sudoku.Client.Commands;
using Sudoku.Client.Common;
using Sudoku.Client.Wrapper;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace Sudoku.Client.ViewModels
{
    public class GameViewModel : ViewModel
    {
        private GameBoardWrapper gameBoard;
        private GameRepository gameRepository;
        private Puzzle puzzle;
        private bool isLoading;
        private Difficulty difficulty;
        private string gameMessage;

        public GameViewModel()
        {
            Init();
        }

        private void Init()
        {
            puzzle = PuzzleFactory.GetPuzzle(Difficulty);
            gameRepository = new GameRepository();

            New = new Command(async () => await NewCommandAsync());
            Solve = new Command(async () => await SolveCommandAsync());
            Check = new Command(async () => await CheckPuzzleAsync());
            Save = new Command(async () => await SavePuzzleAsync());
            Difficulty = Difficulty.Easy;

            
        }

        public GameBoardWrapper GameBoard
        {
            get { return gameBoard; }
            set { SetProperty(ref gameBoard, value); }
        }

        public bool IsLoading
        {
            get { return isLoading; }
            private set { SetProperty(ref isLoading, value); }
        }

        public List<Difficulty> Difficulties => Enum.GetValues(typeof(Difficulty)).Cast<Difficulty>().ToList();
        public Difficulty Difficulty
        {
            get { return difficulty; }
            set { SetProperty(ref difficulty, value); }
        }
        
        public string GameMessage
        {
            get { return gameMessage; }
            set { SetProperty(ref gameMessage, value); }
        }

        public Command New { get; private set; }
        public Command Solve { get; private set; }
        public Command Check { get; private set; }
        public Command Save { get; private set; }

        private void Load(int? puzzleId = null)
        {
            puzzle = puzzleId.HasValue ?
                gameRepository.GetPuzzleById(puzzleId.Value) :
                PuzzleFactory.GetPuzzle(Difficulty);
        }

        private async Task NewCommandAsync()
        {
            IsLoading = true;
            GameMessage = string.Empty;
            try
            {
                puzzle = PuzzleFactory.GetPuzzle(Difficulty);
                await Task.Run(() => puzzle.CreatePuzzle());
                GameBoard = new GameBoardWrapper(new GameBoard(puzzle.PuzzleArray));
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task SolveCommandAsync()
        {
            IsLoading = true;
            try
            {
                await Task.Run(() => puzzle.Solve());
                GameBoard = new GameBoardWrapper(new GameBoard(puzzle.SolvedPuzzleArray));

                //GameBoard.PropertyChanged += (s, e) =>
                //{
                //    if (e.PropertyName == nameof(GameBoard.IsChanged) && GameBoard.IsValid)
                //    {
                //        this.puzzle.State = ObjectState.Modified;
                //    }
                //};
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task CheckPuzzleAsync()
        {
            IsLoading = true;
            try
            {
                puzzle.PuzzleArray = GameBoard.PuzzleArray;
                var result = await Task.Run(() => puzzle.Check());
                if (result)
                {
                    GameMessage = "Congratulations, you have succssfully completed the puzzle.";
                }
                else
                {
                    GameMessage = "This is not a correct solution.";
                }
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task SavePuzzleAsync()
        {
            IsLoading = true;
            try
            {
                await Task.Run(() => gameRepository.SaveGame(puzzle));
            }
            catch (Exception ex)
            {
                GameMessage = ex.Message;
            }
            finally
            {
                IsLoading = false;
            }
        }
    }


}