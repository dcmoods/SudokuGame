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

        /// <summary>
        /// This method maps a PuzzleEntity object to a Puzzle object.
        /// </summary>
        /// <param name="puzzleEntity">PuzzleEntity to be mapped.</param>
        /// <returns>Puzzle object</returns>
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

        /// <summary>
        /// This method maps a Puzzle object to a PuzzleEntity object.
        /// </summary>
        /// <param name="puzzle">Puzzle object to be mapped.</param>
        /// <returns>PuzzleEntity</returns>
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

        /// <summary>
        /// This method maps arrayEntities to an int array.
        /// </summary>
        /// <param name="arrayEntities">ArrayEntities to be mapped.</param>
        /// <param name="array">Array for results out</param>
        private void MapToArray(List<ArrayEntity> arrayEntities, out int[,] array)
        {
            int size = arrayEntities.Count;
            array = new int[size,size];
            foreach (var entity in arrayEntities)
            {
                array[entity.RowIndex, entity.ColumnIndex] = entity.Value;
            }
        }

        /// <summary>
        /// This method maps an int array to ArrayEntity objects.
        /// </summary>
        /// <param name="array">int array to be mapped.</param>
        /// <returns>Collection of ArrayEntity</returns>
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
