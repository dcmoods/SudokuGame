/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*
*                    SUDOKU GAME AND SOLVER
*                                                                       
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*   
*              Name: CancelLoadGameEvent.cs
*     Creation Date: 7/15/2018
*            Author: M. Moody
*  
*       Description: This class is used to create the cancel load game event 
*       that can be subscribed/published by EventAggregate of Prism. 
* 
*	Code Review:	
*  
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using Prism.Events;

namespace Sudoku.Client.Events
{
    /// <summary>
    /// Wire up Prism event to be used by event aggregator
    /// </summary>
    public class CancelLoadGameEvent : PubSubEvent
    {
    }
}
