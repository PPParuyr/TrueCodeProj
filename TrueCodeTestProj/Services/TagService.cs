using Microsoft.EntityFrameworkCore;

namespace TrueCodeTestProj.Services
{
    internal class TagService:ITagService
    {
        private readonly AppDbContext _context;

        public TagService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tag>> GetTagsByValueAndDomainAsync(string tagValue, string domain)
        {
            return await _context.Tags
                .Where(t => t.Value == tagValue && t.Domain == domain)
                .ToListAsync();
        }
    }
}
