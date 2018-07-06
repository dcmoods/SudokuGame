using PuzzleManagement.Core.Enums;
using PuzzleManagement.Core.Models;
using PuzzleManagement.Persistence.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleManagement.Persistence
{
    public class GameRepository
    {
        private DataMappingFactory _mapper;
        public GameRepository()
        {
            _mapper = new DataMappingFactory();
        }

        public List<Puzzle> GetPuzzleList()
        {
            using (var context = new GameContext())
            {
                var puzzleEntities = context.PuzzleEntities.ToList();
                List<Puzzle> puzzles = new List<Puzzle>();
                foreach(var entity in puzzleEntities)
                {
                    puzzles.Add(_mapper.MapPuzzleEntityToPuzzle(entity));
                }
                return puzzles;
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

        public void SaveGame(Puzzle puzzle)
        {
            Contract.Assert(puzzle != null);
            using (var context = new GameContext())
            {
                var puzzleEntity = _mapper.MapPuzzleToPuzzleEntity(puzzle);
                context.PuzzleEntities.Add(puzzleEntity);
                context.Entry(puzzleEntity).State = GetEntityState(puzzle.State);
                foreach(var array in puzzleEntity.WorkingPuzzleArray)
                {
                    context.Entry(array).State = GetEntityState(puzzle.State);
                }
                context.SaveChanges();
            }
        }

        private EntityState GetEntityState(ObjectState state)
        {
            switch (state)
            {
                case ObjectState.Unchanged:
                    return EntityState.Unchanged;
                case ObjectState.Added:
                    return EntityState.Added;
                case ObjectState.Modified:
                    return EntityState.Modified;
                case ObjectState.Deleted:
                    return EntityState.Deleted;
                default:
                    return EntityState.Detached;
            }
        }

    }
}
