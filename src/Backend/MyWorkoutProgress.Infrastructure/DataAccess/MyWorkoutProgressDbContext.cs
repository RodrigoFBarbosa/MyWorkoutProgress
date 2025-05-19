using Microsoft.EntityFrameworkCore;
using MyWorkoutProgress.Domain.Entities;

namespace MyWorkoutProgress.Infrastructure.DataAccess;

public class MyWorkoutProgressDbContext : DbContext
{
    public MyWorkoutProgressDbContext(DbContextOptions options) : base(options) { }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyWorkoutProgressDbContext).Assembly);
    }
}
