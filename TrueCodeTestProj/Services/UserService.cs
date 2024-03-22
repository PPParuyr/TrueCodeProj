using Microsoft.EntityFrameworkCore;
using TrueCodeTestProj;

namespace TrueCodeTestProj.Services
{
    internal class UserService:IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByIdAndDomainAsync(Guid userId, string domain)
        {
            return await _context.Users
                .Include(u => u.TagToUsers)
                    .ThenInclude(tu => tu.Tag)
                .FirstOrDefaultAsync(u => u.UserId == userId && u.Domain == domain);
        }

        public async Task<IEnumerable<User>> GetUsersByDomainAsync(string domain, int page, int pageSize)
        {
            return await _context.Users
                .Where(u => u.Domain == domain)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetUsersByTagAndDomainAsync(string tagValue, string domain)
        {
            return await _context.Users
                .Include(u => u.TagToUsers)
                    .ThenInclude(tu => tu.Tag)
                .Where(u => u.Domain == domain && u.TagToUsers.Any(tu => tu.Tag.Value == tagValue))
                .ToListAsync();
        }
    }
}
