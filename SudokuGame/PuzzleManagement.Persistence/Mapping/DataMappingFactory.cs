using PuzzleManagement.Core.Enums;
using PuzzleManagement.Core.Factories;
using PuzzleManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleManagement.Persistence.Mapping
{
    public class DataMappingFactory
    {

        public DataMappingFactory()
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
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
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
