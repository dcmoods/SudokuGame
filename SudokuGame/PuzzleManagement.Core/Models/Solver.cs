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

        public int[,] SolvedPuzzle { get; private set; }

        public static Solver Create()
        {
            //establish post conditions
            return new Solver();
        }

        public bool Solve(int[,] puzzleArray)
        {
            int row = 0;
            int col = 0;
            //copy puzzle
            SolvedPuzzle = puzzleArray;
            //check for empty cells
            if (!FindEmptyCell(SolvedPuzzle, ref row, ref col)) return true;

            //all possible digits
            for (int number = 1; number <= 9; number++)
            {
                //check if valid
                if (CanUseNumber(SolvedPuzzle, row, col, number))
                {
                    //assign value
                    SolvedPuzzle[row,col] = number;

                    //recursive call to check if solved
                    if (Solve(SolvedPuzzle)) return true;

                    //0 out value and redo
                    SolvedPuzzle[row,col] = 0;

                }
            }
            return false; //trigger backtracking
        }

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

        private bool CanUseNumber(int[,] puzzleArray, int row, int col, int number)
        {
            return !UsedInRow(puzzleArray, row, number) &&
                   !UsedInColumn(puzzleArray, col, number) &&
                   !UsedInSubgrid(puzzleArray, row - row % 3, col - col % 3, number);
        }

        private bool UsedInRow(int[,] puzzleArray, int row, int number)
        {
            for (int col = 0; col < 9; col++)
                if (puzzleArray[row,col] == number)
                    return true;
            return false;
        }

        private bool UsedInColumn(int[,] puzzleArray, int col, int number)
        {
            for (int row = 0; row < 9; row++)
                if (puzzleArray[row,col] == number)
                    return true;
            return false;
        }

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
