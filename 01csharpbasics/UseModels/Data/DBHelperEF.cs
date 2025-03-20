using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UseModels.Models;

namespace UseModels.Data
{
    public class DBHelperEF(IConfiguration config) : DbContext
    {

        private readonly string _config = config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Database connection string not found");

        public DbSet<Computer> Computer { get; set; }

        // To connect to SQL database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_config, optionsBuilder => optionsBuilder.EnableRetryOnFailure());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TutorialAppSchema");
            modelBuilder.Entity<Computer>()
                .HasKey(e => e.ComputerId);
            // manuallu set the default database and schema name
            // .ToTable("Computer", "TutorialAppSchema");
        }

    }
}