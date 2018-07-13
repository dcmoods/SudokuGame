﻿using PuzzleManagement.Core.Models;
using PuzzleManagement.Persistence.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Contracts;
using System.Linq;

namespace PuzzleManagement.Persistence
{
    public class GameRepository
    {
        private DataMappingFactory _mapper;
        public GameRepository(DataMappingFactory mappingFactory)
        {
            _mapper = mappingFactory;
        }

        public List<PuzzleEntity> GetPuzzleList()
        {
            using (var context = new GameContext())
            {
                var puzzleEntities = context.PuzzleEntities.ToList();
                return puzzleEntities;
            }
        }

        public Puzzle GetPuzzleById(int id)
        {
            using (var context = new GameContext())
            {
                var puzzleEntity = context.PuzzleEntities.SingleOrDefault(p => p.Id == id);
                return _mapper.MapPuzzleEntityToPuzzle(puzzleEntity);
            }
        }

        public int SaveGame(Puzzle puzzle)
        {
            Contract.Assert(puzzle != null);
            using (var context = new GameContext())
            {
                var puzzleEntity = _mapper.MapPuzzleToPuzzleEntity(puzzle);

                if(puzzle.Id != 0)
                {
                    var entity = context.PuzzleEntities
                        .Include(p => p.WorkingPuzzleArray)
                        .FirstOrDefault(p => p.Id == puzzleEntity.Id);

                    if (entity == null)
                    {
                        return 0;
                    }

                    foreach (var arrayItem in entity.WorkingPuzzleArray)
                    {
                        var value = puzzle.PuzzleArray[arrayItem.RowIndex, arrayItem.ColumnIndex];
                        arrayItem.Value = value;
                    }

                    context.Entry(entity).CurrentValues.SetValues(puzzleEntity);
                }
                else
                {
                    context.PuzzleEntities.Add(puzzleEntity);                    
                    foreach(var array in puzzleEntity.WorkingPuzzleArray)
                    {
                        context.Entry(array).State = EntityState.Added;
                    }
                }

                context.SaveChanges();
                return puzzleEntity.Id;
            }
        }

    }
}