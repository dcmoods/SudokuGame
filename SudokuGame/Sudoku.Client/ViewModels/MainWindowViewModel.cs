using Prism.Events;
using Sudoku.Client.Common;
using Sudoku.Client.DI;
using Sudoku.Client.Events;
using System;
using System.Diagnostics.Contracts;
using Unity;

namespace Sudoku.Client.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private IEventAggregator _eventAggregator;

        private ViewModel _currentViewModel;
        private GameViewModel _gameViewModel;
        private LoadGameViewModel _loadGameViewModel;

        public MainWindowViewModel()
        {
            _eventAggregator = ContainerHelper.Container.Resolve<IEventAggregator>();
            _loadGameViewModel = ContainerHelper.Container.Resolve<LoadGameViewModel>();
            _gameViewModel = ContainerHelper.Container.Resolve<GameViewModel>();

            _eventAggregator.GetEvent<LoadGameEvent>().Subscribe(GameLoaded);
            _eventAggregator.GetEvent<OpenLoadGameEvent>().Subscribe(OnOpenLoadGame);

            CurrentViewModel = GameViewModel;
        }

        public ViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel, value); }
        }

        public GameViewModel GameViewModel
        {
            get { return _gameViewModel; }
            set { SetProperty(ref _gameViewModel, value);}
        }

        public LoadGameViewModel LoadGameViewModel
        {
            get { return _loadGameViewModel; }
            set { SetProperty(ref _loadGameViewModel, value); }
        }

        async void GameLoaded(int puzzleId)
        {
            Contract.Requires(GameViewModel != null);
            await GameViewModel.LoadPuzzle(puzzleId);
            CurrentViewModel = GameViewModel;
        }

        void OnOpenLoadGame()
        {
            CurrentViewModel = LoadGameViewModel;
        }
    }
}
