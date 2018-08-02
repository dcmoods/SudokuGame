/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*
*                    SUDOKU GAME AND SOLVER
*                                                                       
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*   
*              Name: LoadGameViewModel.cs
*     Creation Date: 7/15/2018
*            Author: M. Moody
*  
*       Description: This class defines the logic used in loading a game by the UI.
* 
*	Code Review:	
*  
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using Prism.Events;
using PuzzleManagement.Core.Models;
using PuzzleManagement.Persistence;
using Sudoku.Client.Commands;
using Sudoku.Client.Common;
using Sudoku.Client.Events;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Sudoku.Client.ViewModels
{
    public class LoadGameViewModel : ViewModel
    {
        private GameRepository _gameRepository;
        private IEventAggregator _eventAggregator;

        private List<PuzzleEntity> _savedPuzzles;
        private PuzzleEntity _selectedPuzzle;

        public LoadGameViewModel(IEventAggregator eventAggregator,
                                 GameRepository gameRepository)
        {            
            Contract.Requires(gameRepository != null);
            Contract.Requires(eventAggregator != null);

            _gameRepository = gameRepository;
            _eventAggregator = eventAggregator;
            _savedPuzzles = new List<PuzzleEntity>();

            Load = new Command(LoadCommand);
            Cancel = new Command(CancelCommand);

            RefreshSaves();
        }

        /// <summary>
        /// This method refreshes the saved games
        /// </summary>
        public void RefreshSaves()
        {
            SavedPuzzles = _gameRepository.GetPuzzleList();
        }

        public Command Load { get; private set; }
        public Command Cancel { get; private set; }

        public List<PuzzleEntity> SavedPuzzles
        {
            get { return _savedPuzzles; }
            set { SetProperty(ref _savedPuzzles, value); }
        }

        public PuzzleEntity SelectedPuzzle
        {
            get { return _selectedPuzzle; }
            set { SetProperty(ref _selectedPuzzle, value); }
        }

        private void LoadCommand()
        {
            _eventAggregator.GetEvent<LoadGameEvent>().Publish(SelectedPuzzle.Id);
        }

        private void CancelCommand()
        {
            _eventAggregator.GetEvent<CancelLoadGameEvent>().Publish();
        }
    }
}
