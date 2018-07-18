/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*
*                    SUDOKU GAME AND SOLVER
*                                                                       
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*   
*              Name: PuzzleMapper.cs
*     Creation Date: 7/11/2018
*            Author: M. Moody
*  
*       Description: This file is used for Mapping Puzzles to PuzzleEntities
*                    before persistence and fetching.
* 
*	Code Review:	
*  
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using PuzzleManagement.Core.Enums;
using PuzzleManagement.Core.Factories;
using PuzzleManagement.Core.Models;
using System;
using System.Collections.Generic;

namespace PuzzleManagement.Persistence.Mapping
{
    public class PuzzleMapper
    {

        public PuzzleMapper()
        {
        }

        public Puzzle MapPuzzleEntityToPuzzle(PuzzleEntity puzzleEntity)
        {
            var difficulty = (Difficulty)puzzleEntity.Difficulty;
            var puzzle = PuzzleFactory.GetPuzzle(difficulty);
            puzzle.Id = puzzleEntity.Id;
            int[,] array;
            MapToArray(puzzleEntity.WorkingPuzzleArray, out array);
            puzzle.PuzzleArray = array;
            return puzzle;
        }

        public PuzzleEntity MapPuzzleToPuzzleEntity(Puzzle puzzle)
        {
            PuzzleEntity puzzleEntity = new PuzzleEntity()
            {
                Id = puzzle.Id,
                Difficulty = (int)puzzle.Difficulty,
                LastSave = DateTime.Now.ToString(),
                WorkingPuzzleArray = MapToArrayEntity(puzzle.PuzzleArray),
            };

            return puzzleEntity;
        }

        private void MapToArray(List<ArrayEntity> arrayEntities, out int[,] array)
        {
            int size = arrayEntities.Count;
            array = new int[size,size];
            foreach (var entity in arrayEntities)
            {
                array[entity.RowIndex, entity.ColumnIndex] = entity.Value;
            }
        }

        private List<ArrayEntity> MapToArrayEntity(int[,] array)
        {
            List<ArrayEntity> arrayEntities = new List<ArrayEntity>();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    ArrayEntity arrayEntity = new ArrayEntity();
                    arrayEntity.RowIndex = i;
                    arrayEntity.ColumnIndex = j;
                    arrayEntity.Value = array[i, j];
                    arrayEntities.Add(arrayEntity);
                }
            }
            return arrayEntities;
        }

    }
}
