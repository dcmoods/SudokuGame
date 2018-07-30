/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*
*                    SUDOKU GAME AND SOLVER
*                                                                       
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*   
*              Name: Generator.cs
*     Creation Date: 6/20/2018
*            Author: M. Moody
*  
*       Description: This file defines a generator object 
*       that is responsible for the generating Sudoku puzzles.
* 
*	Code Review:	
*  
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using PuzzleManagement.Core.Enums;
using System;
using System.Diagnostics.Contracts;

namespace PuzzleManagement.Core.Models
{
    public class Generator
    {

        private const int GRIDSIZE = 9; //Main gird size of board
        private const int SUBGRIDSIZE = 3; //Subgrid size of board

        private Difficulty _difficulty; //Difficulty to be set
        private int[,] _puzzleArray; //int array to store generated puzzle.


        /// <summary>
        /// Factory method for construction.
        /// </summary>
        /// <param name="difficulty">Level of difficulty</param>
        /// <returns>Generator Object</returns>
        public static Generator Create(Difficulty difficulty)
        {
            Contract.Result<Generator>();
            return new Generator(difficulty);
        }

        private Generator(Difficulty difficulty)
        {
            _puzzleArray = new int[GRIDSIZE,GRIDSIZE];
            _difficulty = difficulty;
        }

        /// <summary>
        /// This method generates a new puzzle array.
        /// </summary>
        /// <returns>int puzzle array.</returns>
        public int[,] Generate()
        {
            FillDiagonal();
            FillRemaining(0, SUBGRIDSIZE);
            UpdateForDifficulty();
            return _puzzleArray;
        }


        /// <summary>
        /// This method fills the array subgrids diagonally. 
        /// </summary>
        private void FillDiagonal()
        {
            for (int i = 0; i < GRIDSIZE; i = i + SUBGRIDSIZE)
            {
                FillSubgrid(i, i);
            }
        }

        /// <summary>
        /// This method generates a random number 1 - 9
        /// </summary>
        /// <returns>random number 1 - 9</returns>
        private int GetRandomNumber()
        {
            var rnd = new Random();
            //returns a number between 1-9
            return rnd.Next(1, 10);
        }


        /// <summary>
        /// This method fills a subgrid with values.
        /// </summary>
        /// <param name="row">Starting row location of array.</param>
        /// <param name="col">Starting column location of array.</param>
        private void FillSubgrid(int row, int col)
        {
            int number = 0;
            for (int subRow = 0; subRow < SUBGRIDSIZE; subRow++)
            {
                for (int subCol = 0; subCol < SUBGRIDSIZE; subCol++)
                {
                    do
                    {
                        number = GetRandomNumber();
                    }
                    while (UsedInSubgrid(row, col, number));

                    this._puzzleArray[row + subRow,col + subCol] = number;
                }
            }
        }


        /// <summary>
        /// This method fills the remaining cells of the int array
        /// </summary>
        /// <param name="row">Starting row location of array.</param>
        /// <param name="col">Starting column location of array.</param>
        /// <returns>recursive call</returns>
        private bool FillRemaining(int row, int col)
        {
            if (col >= GRIDSIZE && row < GRIDSIZE - 1)
            {
                row = row + 1;
                col = 0;
            }

            if (row >= GRIDSIZE && col >= GRIDSIZE)
                return true;

            if (row < SUBGRIDSIZE)
            {
                if (col < SUBGRIDSIZE)
                {
                    col = SUBGRIDSIZE;
                }
            }
            else if (row < GRIDSIZE - SUBGRIDSIZE)
            {
                if (col == ((int)(row / SUBGRIDSIZE) * SUBGRIDSIZE))
                {
                    col = (col + SUBGRIDSIZE);
                }
            }
            else
            {
                if (col == GRIDSIZE - SUBGRIDSIZE)
                {
                    row = row + 1;
                    col = 0;
                    if (row >= GRIDSIZE)
                    {
                        return true;
                    }
                }
            }

            for (int number = 1; number <= GRIDSIZE; number++)
            {
                if (CanUseNumber(row, col, number))
                {
                    _puzzleArray[row, col] = number;
                    if (FillRemaining(row, col + 1))
                    {
                        return true;
                    }

                    _puzzleArray[row, col] = 0;
                }
            }
            return false;
        }

        /// <summary>
        /// This method checks if a value is used in a row.
        /// </summary>
        /// <param name="row">Row to check</param>
        /// <param name="number">Value to check</param>
        /// <returns>if value is used in the row</returns>
        private bool UsedInRow(int row, int number)
        {
            for (int col = 0; col < 9; col++)
                if (_puzzleArray[row,col] == number)
                    return true;
            return false;
        }

        /// <summary>
        /// This method checks if a value is used in a column.
        /// </summary>
        /// <param name="col">Column to check</param>
        /// <param name="number">Value to check</param>
        /// <returns>if value is used in the column</returns>
        private bool UsedInColumn(int col, int number)
        {
            for (int row = 0; row < 9; row++)
                if (_puzzleArray[row,col] == number)
                    return true;
            return false;
        }

        /// <summary>
        /// This method checks if a value is used in a column.
        /// </summary>
        /// <param name="startRow">Starting row to check</param>
        /// <param name="startCol">Starting column to check</param>
        /// <param name="number">value to check</param>
        /// <returns>if value is used in subgrid</returns>
        private bool UsedInSubgrid(int startRow, int startCol, int number)
        {
            for (int row = 0; row < 3; row++)
                for (int col = 0; col < 3; col++)
                    if (_puzzleArray[row + startRow,col + startCol] == number)
                        return true;
            return false;
        }

        /// <summary>
        /// This method checks if the value can be used.
        /// </summary>
        /// <param name="row">Row to check</param>
        /// <param name="col">Column to check</param>
        /// <param name="number">Value to check</param>
        /// <returns>if the value can be used</returns>
        private bool CanUseNumber(int row, int col, int number)
        {
            return !UsedInRow(row, number) &&
                   !UsedInColumn(col, number) &&
                   !UsedInSubgrid(row - row % 3, col - col % 3, number);
        }

        /// <summary>
        /// Updates the int array for the selected difficulty,
        /// by iterating the array and updating random value locations to 0.
        /// </summary>
        private void UpdateForDifficulty()
        {
            int count = (int)this._difficulty;
            while (count != 0)
            {
                Random rnd = new Random();
                int cell = rnd.Next(0, (GRIDSIZE * GRIDSIZE));
                
                int row = (cell / GRIDSIZE);
                int col = (cell % GRIDSIZE);
                
                if (_puzzleArray[row,col] != 0)
                {
                    count--;
                    _puzzleArray[row,col] = 0;
                }
            }
        }
    }
}
