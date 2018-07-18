/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*
*                    SUDOKU GAME AND SOLVER
*                                                                       
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*   
*              Name: LoadGameEvent.cs
*     Creation Date: 7/15/2018
*            Author: M. Moody
*  
*       Description: This class is used create the load game event 
*       that can be subscribed/published by EventAggregate of Prism. 
* 
*	Code Review:	
*  
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using Prism.Events;

namespace Sudoku.Client.Events
{
    public class LoadGameEvent : PubSubEvent<int>
    {
    }
}
