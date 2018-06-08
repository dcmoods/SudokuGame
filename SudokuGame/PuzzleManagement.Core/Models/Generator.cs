using PuzzleManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleManagement.Core.Models
{
    public class Generator
    {

        private const int GRIDSIZE = 9;
        private const int SUBGRIDSIZE = 3;

        private Difficulty _difficulty;
        private int[,] _puzzleArray;

        public static Generator Create(Difficulty difficulty)
        {
            return new Generator(difficulty);
        }

        private Generator(Difficulty difficulty)
        {
            _puzzleArray = new int[GRIDSIZE,GRIDSIZE];
            _difficulty = difficulty;
        }

        public int[,] Generate()
        {
            FillDiagonal();
            FillRemaining(0, SUBGRIDSIZE);
            UpdateForDifficulty();
            return _puzzleArray;
        }

        private void FillDiagonal()
        {
            for (int i = 0; i < GRIDSIZE; i = i + SUBGRIDSIZE)
            {
                FillSubgrid(i, i);
            }
        }

        private int GetRandomNumber()
        {
            var rnd = new Random();
            //returns a number between 1-9
            return rnd.Next(1, 10);
        }

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

        private bool UsedInRow(int row, int number)
        {
            for (int col = 0; col < 9; col++)
                if (_puzzleArray[row,col] == number)
                    return true;
            return false;
        }

        private bool UsedInColumn(int col, int number)
        {
            for (int row = 0; row < 9; row++)
                if (_puzzleArray[row,col] == number)
                    return true;
            return false;
        }

        private bool UsedInSubgrid(int startRow, int startCol, int number)
        {
            for (int row = 0; row < 3; row++)
                for (int col = 0; col < 3; col++)
                    if (_puzzleArray[row + startRow,col + startCol] == number)
                        return true;
            return false;
        }

        private bool CanUseNumber(int row, int col, int number)
        {
            return !UsedInRow(row, number) &&
                   !UsedInColumn(col, number) &&
                   !UsedInSubgrid(row - row % 3, col - col % 3, number);
        }

        private void UpdateForDifficulty()
        {
            int count = (int)this._difficulty;
            while (count != 0)
            {
                Random rnd = new Random();
                int cell = rnd.Next(0, GRIDSIZE * GRIDSIZE);

                int row = (cell / GRIDSIZE);
                int col = (cell % GRIDSIZE);
                if (col != 0)
                {
                    col = col - 1;
                }

                if (_puzzleArray[row,col] != 0)
                {
                    count--;
                    _puzzleArray[row,col] = 0;
                }
            }
        }
    }
}
