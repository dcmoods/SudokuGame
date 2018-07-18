/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*
*                    SUDOKU GAME AND SOLVER
*                                                                       
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*   
*              Name: IStateObject.cs
*     Creation Date: 6/20/2018
*            Author: M. Moody
*  
*       Description: This enum is used to define the state of 
*                    an object that implements the interface.
* 
*	Code Review:	
*  
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using PuzzleManagement.Core.Enums;

namespace PuzzleManagement.Core.Interfaces
{
    public interface IStateObject
    {
        ObjectState State { get; set; }
    }
}
