using Microsoft.EntityFrameworkCore;
using UseModels.Models;

namespace UseModels.Data
{
    public class DBHelperEF : DbContext
    {
        public DbSet<Computer> Computer { get; set; }

        // To connect to SQL database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=dotnet1;TrustServerCertificate=true;Trusted_Connection=true;", optionsBuilder => optionsBuilder.EnableRetryOnFailure());
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