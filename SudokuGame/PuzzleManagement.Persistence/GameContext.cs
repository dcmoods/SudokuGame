/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*
*                    SUDOKU GAME AND SOLVER
*                                                                       
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*   
*              Name: GameContext.cs
*     Creation Date: 7/11/2018
*            Author: M. Moody
*  
*       Description: This file defines the context used 
*                    by the ORM to access the database. 
* 
*	Code Review:	
*  
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using PuzzleManagement.Core.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PuzzleManagement.Persistence
{
    public class GameContext : DbContext
    {
        public DbSet<PuzzleEntity> PuzzleEntities { get; set; }
        public DbSet<ArrayEntity> WorkingPuzzleArrays { get; set; }

        public GameContext()
        {
            Database.SetInitializer<GameContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
