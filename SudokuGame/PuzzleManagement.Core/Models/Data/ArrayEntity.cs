/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*
*                    SUDOKU GAME AND SOLVER
*                                                                       
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*   
*              Name: ArrayEntity.cs
*     Creation Date: 7/11/2018
*            Author: M. Moody
*  
*       Description: This file defines an ArrayEntity object, 
*                    used for persistence of a puzzle array. 
* 
*	Code Review:	
*  
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

namespace PuzzleManagement.Core.Models
{
    public class ArrayEntity
    {
        public int Id { get; set; }
        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }
        public int Value { get; set; }
        public int PuzzleEntityId { get; set; }
    }
}
