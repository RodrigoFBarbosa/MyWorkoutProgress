using MyWorkoutProgress.Domain.Repositories;

namespace MyWorkoutProgress.Infrastructure.DataAccess;

public class UnitOfWork : IUnitOfWork
{
    private readonly MyWorkoutProgressDbContext _dbContext;

    public UnitOfWork(MyWorkoutProgressDbContext dbContext) => _dbContext = dbContext;

    public async Task Commit() => await _dbContext.SaveChangesAsync();
}
