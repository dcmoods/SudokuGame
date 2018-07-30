/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*
*                    SUDOKU GAME AND SOLVER
*                                                                       
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*   
*              Name: ContainerHelper.cs
*     Creation Date: 7/15/2018
*            Author: M. Moody
*  
*       Description: This static class registers types for with the 
*       DI Container and is used to resolve those types at runtime. 
* 
*	Code Review:	
*  
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using Prism.Events;
using PuzzleManagement.Persistence;
using PuzzleManagement.Persistence.Mapping;
using Unity;
using Unity.Lifetime;

namespace Sudoku.Client.DI
{
    public static class ContainerHelper
    {
        private static IUnityContainer _container; //container for DI
        public static IUnityContainer Container
        {
            get { return _container; }
        }

        /// <summary>
        /// This method is used to setup DI with Unity.
        /// </summary>
        static ContainerHelper()
        {
            _container = new UnityContainer();
            _container.RegisterType<IEventAggregator, EventAggregator>(new ContainerControlledLifetimeManager());
            _container.RegisterType<PuzzleMapper>();
            _container.RegisterType<GameRepository>();
        }


    }
}
