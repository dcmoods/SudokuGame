using Prism.Events;
using PuzzleManagement.Core.Enums;
using PuzzleManagement.Core.Factories;
using PuzzleManagement.Core.Models;
using PuzzleManagement.Persistence;
using Sudoku.ApplicationLayer.Models;
using Sudoku.Client.Commands;
using Sudoku.Client.Common;
using Sudoku.Client.Events;
using Sudoku.Client.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sudoku.Client.ViewModels
{
    public class GameViewModel : ViewModel
    {
        private GameRepository _gameRepository;
        private IEventAggregator _eventAggregator;
        private GameBoardWrapper gameBoard;
        private Puzzle puzzle;
        private bool isLoading;
        private Difficulty difficulty;
        private string gameMessage;

        public GameViewModel(IEventAggregator eventAggregator,
                             GameRepository gameRepository)
        {
            _gameRepository = gameRepository;
            _eventAggregator = eventAggregator;

            New = new Command(async () => await NewCommandAsync());
            Solve = new Command(async () => await SolveCommandAsync());
            Check = new Command(async () => await CheckPuzzleAsync());
            Save = new Command(async () => await SavePuzzleAsync());
            Load = new Command(LoadCommand);
            puzzle = PuzzleFactory.GetPuzzle(Difficulty);
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
        public Command Load { get; private set; }

        public async Task LoadPuzzle(int? puzzleId = null)
        {
            if (puzzleId.HasValue)
            {
                puzzle = _gameRepository.GetPuzzleById(puzzleId.Value);
                GameBoard = new GameBoardWrapper(new GameBoard(puzzle.PuzzleArray));
            }
            else
            {
                puzzle = PuzzleFactory.GetPuzzle(Difficulty);
                await Task.Run(() => puzzle.CreatePuzzle());
                GameBoard = new GameBoardWrapper(new GameBoard(puzzle.PuzzleArray)
                {
                    State = ObjectState.Added
                });
            }
        }

        private async Task NewCommandAsync()
        {
            IsLoading = true;
            GameMessage = string.Empty;
            try
            {
                await LoadPuzzle();
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
                GameBoard.RejectChanges();
                await Task.Run(() => puzzle.Solve());
                GameBoard = new GameBoardWrapper(new GameBoard(puzzle.SolvedPuzzleArray));
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
                await SavePuzzleAsync();
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
                puzzle.State = GameBoard.State;
                var puzzleId = await Task.Run(() => _gameRepository.SaveGame(puzzle));
                GameBoard.AcceptChanges();
                await LoadPuzzle(puzzleId);
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

        private void LoadCommand()
        {
            _eventAggregator.GetEvent<OpenLoadGameEvent>().Publish();
        }

    }


}