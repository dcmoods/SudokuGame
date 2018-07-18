/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*
*                    SUDOKU GAME AND SOLVER
*                                                                       
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*   
*              Name: PuzzleEntity.cs
*     Creation Date: 7/11/2018
*            Author: M. Moody
*  
*       Description: This file defines an PuzzleEntity object, 
*                    used for persistence of a puzzle.
* 
*	Code Review:	
*  
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using System.Collections.Generic;

namespace PuzzleManagement.Core.Models
{
    public class PuzzleEntity
    {
        public PuzzleEntity()
        {
            WorkingPuzzleArray = new List<ArrayEntity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Difficulty { get; set; }
        public int TimeElapsed { get; set; }
        public string LastSave { get; set; }
        public virtual List<ArrayEntity> WorkingPuzzleArray { get; set; }
    }
}
