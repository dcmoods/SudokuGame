/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*
*                    SUDOKU GAME AND SOLVER
*                                                                       
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*   
*              Name: GameRepository.cs
*     Creation Date: 7/11/2018
*            Author: M. Moody
*  
*       Description: This file defines a Repository for persistence of puzzles. 
* 
*	Code Review:	
*  
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using PuzzleManagement.Core.Models;
using PuzzleManagement.Persistence.Mapping;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Contracts;
using System.Linq;

namespace PuzzleManagement.Persistence
{
    public class GameRepository
    {
        private PuzzleMapper _mapper; //PuzzleMapper object used for mapping data before/after persistence. 

        public GameRepository(PuzzleMapper mappingFactory)
        {
            _mapper = mappingFactory;
        }

        /// <summary>
        /// This method returns a list of Puzzle objects from the datastore.
        /// </summary>
        /// <returns>list of Puzzle objects</returns>
        public List<PuzzleEntity> GetPuzzleList()
        {
            using (var context = new GameContext())
            {
                var puzzleEntities = context.PuzzleEntities.ToList();
                return puzzleEntities;
            }
        }

        /// <summary>
        /// This method gets a puzzle object by id from the datastore.
        /// </summary>
        /// <param name="id">Puzzle id</param>
        /// <returns>Puzzle</returns>
        public Puzzle GetPuzzleById(int id)
        {
            using (var context = new GameContext())
            {
                var puzzleEntity = context.PuzzleEntities.SingleOrDefault(p => p.Id == id);
                return _mapper.MapPuzzleEntityToPuzzle(puzzleEntity);
            }
        }

        /// <summary>
        /// This method saves a puzzle object data to the datastore
        /// after mapping its data to a PuzzleEntity object.
        /// </summary>
        /// <param name="puzzle">Puzzle to save.</param>
        /// <returns>Puzzle id after saved</returns>
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

        /// <summary>
        /// This method deletes a puzzle from the datastore
        /// </summary>
        /// <param name="puzzle">Puzzle to be deleted</param>
        public void DeletePuzzle(Puzzle puzzle)
        {
            Contract.Assert(puzzle != null);
            using (var context = new GameContext())
            {
                var puzzleEntity = context.PuzzleEntities.Find(puzzle.Id);
                context.Entry(puzzleEntity).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

    }
}
