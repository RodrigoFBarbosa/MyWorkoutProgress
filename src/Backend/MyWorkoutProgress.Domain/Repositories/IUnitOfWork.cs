namespace MyWorkoutProgress.Domain.Repositories;

public interface IUnitOfWork
{
    public Task Commit();
}
