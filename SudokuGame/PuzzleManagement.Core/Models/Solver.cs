/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*
*                    SUDOKU GAME AND SOLVER
*                                                                       
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*   
*              Name: Solver.cs
*     Creation Date: 6/20/2018
*            Author: M. Moody
*  
*       Description: This file defines a solver object 
*       that is responsible for the solving Sudoku puzzles.
* 
*	Code Review:	
*  
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

namespace PuzzleManagement.Core.Models
{
    public class Solver
    {
        private Solver()
        {
        }

        public int[,] SolvedPuzzle { get; private set; } //this property stores the solved puzzle.

        /// <summary>
        /// Factory create method for the Solver.
        /// </summary>
        /// <returns>Solver Object</returns>
        public static Solver Create()
        {
            return new Solver();
        }

        /// <summary>
        /// This method iterates the int array and solves the sudoku puzzle
        /// </summary>
        /// <param name="puzzleArray">Sudoku puzzle int array.</param>
        /// <returns>Puzzle successful solved.</returns>
        public bool Solve(int[,] puzzleArray)
        {
            int row = 0; //This value is for rows
            int col = 0; //This value is for columns
            
            SolvedPuzzle = puzzleArray; //copy puzzle
            
            if (!FindEmptyCell(SolvedPuzzle, ref row, ref col)) return true; 
            
            for (int number = 1; number <= 9; number++) 
            {
                if (CanUseNumber(SolvedPuzzle, row, col, number)) 
                {
                    SolvedPuzzle[row,col] = number; 
                    if (Solve(SolvedPuzzle)) return true; 
                    SolvedPuzzle[row,col] = 0; 
                }
            }
            return false; 
        }

        /// <summary>
        /// This method checks if the cell is empty.
        /// </summary>
        /// <param name="puzzleArray">Current puzzle array.</param>
        /// <param name="row">row location to check</param>
        /// <param name="col">column location to check</param>
        /// <returns>if cell is empty.</returns>
        private bool FindEmptyCell(int[,] puzzleArray, ref int row, ref int col)
        {
            for (row = 0; row < 9; row++) 
            {
                for (col = 0; col < 9; col++) 
                {
                    if (puzzleArray[row,col] == 0) return true; 
                }
            }
            return false;
        }


        /// <summary>
        /// This method checks if the value used for solving a cell is a valid  .
        /// </summary>
        /// <param name="puzzleArray">Current puzzle array</param>
        /// <param name="row">row location to check</param>
        /// <param name="col">column location to check</param>
        /// <param name="number">value to be checked.</param>
        /// <returns>if the value can be used in the cell.</returns>
        private bool CanUseNumber(int[,] puzzleArray, int row, int col, int number)
        {
            return !UsedInRow(puzzleArray, row, number) &&
                   !UsedInColumn(puzzleArray, col, number) &&
                   !UsedInSubgrid(puzzleArray, row - row % 3, col - col % 3, number);
        }

        /// <summary>
        /// This method checks if a value is used in the current row
        /// </summary>
        /// <param name="puzzleArray">Current puzzle array</param>
        /// <param name="row">Current row location to check</param>
        /// <param name="number">value to be checked</param>
        /// <returns>if the value is used in the current row.</returns>
        private bool UsedInRow(int[,] puzzleArray, int row, int number)
        {
            for (int col = 0; col < 9; col++)
                if (puzzleArray[row,col] == number)
                    return true;
            return false;
        }

        /// <summary>
        /// This method checks if a value is used in the current column
        /// </summary>
        /// <param name="puzzleArray">Current puzzle array</param>
        /// <param name="col">Current column location to check</param>
        /// <param name="number">value to be checked</param>
        /// <returns>if the value is used in the current column.</returns>
        private bool UsedInColumn(int[,] puzzleArray, int col, int number)
        {
            for (int row = 0; row < 9; row++)
                if (puzzleArray[row,col] == number)
                    return true;
            return false;
        }


        /// <summary>
        /// This method checks if a value is used in the current 3x3 Subgrid.
        /// </summary>
        /// <param name="puzzleArray">Current puzzle array</param>
        /// <param name="startRow">Start row location to check</param>
        /// <param name="startCol">Start column location to check</param>
        /// <param name="number">value to be checked</param>
        /// <returns>If the value is in the current subgrid</returns>
        private bool UsedInSubgrid(int[,] puzzleArray, int startRow, int startCol, int number)
        {
            for (int row = 0; row < 3; row++)
                for (int col = 0; col < 3; col++)
                    if (puzzleArray[row + startRow,col + startCol] == number)
                        return true;
            return false;
        }
    }
}
