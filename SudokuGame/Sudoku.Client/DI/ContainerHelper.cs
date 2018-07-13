using Prism.Events;
using PuzzleManagement.Persistence;
using PuzzleManagement.Persistence.Mapping;
using Sudoku.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace Sudoku.Client.DI
{
    public static class ContainerHelper
    {
        private static IUnityContainer _container;
        public static IUnityContainer Container
        {
            get { return _container; }
        }

        static ContainerHelper()
        {
            _container = new UnityContainer();
            _container.RegisterType<IEventAggregator, EventAggregator>(new ContainerControlledLifetimeManager());
            _container.RegisterType<DataMappingFactory>();
            _container.RegisterType<GameRepository>();
        }


    }
}
