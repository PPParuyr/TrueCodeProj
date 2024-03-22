using Microsoft.EntityFrameworkCore;
using TrueCodeProj.Models;

namespace TrueCodeTestProj.Services
{
    internal class UserService:IUserService
    {
        private readonly AppDbContext _dbContext;

        public UserService(AppDbContext context)
        {
            _dbContext = context;
        }


        public async Task<User?> GetUserByIdAndDomainAsync(Guid userId, string domain)
        {
            return await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.UserId == userId && u.Domain == domain);
        }

        public async Task<List<User>> GetUsersByDomainAsync(string domain, int page, int pageSize)
        {
            return await _dbContext.Users
                .AsNoTracking()
                .Where(u => u.Domain == domain)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<List<User>> GetUsersByTagAndDomainAsync(string tagValue, string domain)
        {
            return await _dbContext.Users
                .AsNoTracking()
                .Where(u => u.Domain == domain && u.TagToUsers.Any(tt => tt.Tag.Value == tagValue))
                .ToListAsync();
        }
    }
}
