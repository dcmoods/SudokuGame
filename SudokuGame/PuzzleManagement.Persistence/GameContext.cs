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
