using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Users.Core.Entities;
using SurveyStore.Modules.Users.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Users.Core.DAL.Repositories
{
    internal sealed class PostgresUserRepository : IUserRepository
    {
        private readonly DbSet<User> _users;
        private readonly UsersDbContext _dbContext;

        public PostgresUserRepository(UsersDbContext dbContext)
        {
            _users = dbContext.Users;
            _dbContext = dbContext;
        }

        public async Task AddAsync(User user)
        {
            await _users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            _users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }

        public Task<User> GetByEmailAsync(string email)
            => _users.SingleOrDefaultAsync(u => u.Email == email);

        public Task<User> GetByIdAsync(Guid id)
            => _users.SingleOrDefaultAsync(u => u.Id == id);

        public async Task UpdateAsync(User user)
        {
            _users.Update(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
