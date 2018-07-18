/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*
*                    SUDOKU GAME AND SOLVER
*                                                                       
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*   
*              Name: ObjectState.cs
*     Creation Date: 7/11/2018
*            Author: M. Moody
*  
*       Description: This file defines an enum for Object state, used for tracking state. 
* 
*	Code Review:	
*  
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

namespace PuzzleManagement.Core.Enums
{
    public enum ObjectState
    {
        Unchanged,
        Added,
        Modified,
        Deleted,
        Detached
    }
}
