using Microsoft.EntityFrameworkCore;
using MyWorkoutProgress.Domain.Entities;
using MyWorkoutProgress.Domain.Repositories.User;

namespace MyWorkoutProgress.Infrastructure.DataAccess.Repositories;

internal class UserRepository : IUserWriteOnlyRepository, IUserReadOnlyRepository
{
    private readonly MyWorkoutProgressDbContext _dbContext;

    public UserRepository(MyWorkoutProgressDbContext dbContext) => _dbContext = dbContext;

    public async Task Add(User user) => await _dbContext.Users.AddAsync(user);

    public async Task <bool> ExistActiveUserWithEmail(string email) => await _dbContext
        .Users
        .AnyAsync(user => user.Email.Equals(email) && user.IsActive);

    public async Task<User?> GetByEmailAndPassword(string email, string password)
    {
        return await _dbContext
            .Users
            .AsNoTracking()
            .FirstOrDefaultAsync(user => user.IsActive && user.Email.Equals(email) && user.Password.Equals(password));
    }
}
