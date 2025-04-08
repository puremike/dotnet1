using FirstAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Data;

public class DBHelperEF(IConfiguration config) : DbContext
{
    private readonly string _connectionString = config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Database connection string can't be found");

    public DbSet<User> Users { get; set; }
    public DbSet<UserSalary> UserSalary { get; set; }
    public DbSet<UserJobInfo> UserJobInfo { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_connectionString, optionsBuilder => optionsBuilder.EnableRetryOnFailure());
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("TutorialAppSchema");
        modelBuilder.Entity<User>()
        .ToTable("Users", "TutorialAppSchema")
        .HasKey(u => u.UserId);

        modelBuilder.Entity<UserSalary>()
        .HasKey(u => u.UserId);

        modelBuilder.Entity<UserJobInfo>()
        .HasKey(u => u.UserId);
    }

}