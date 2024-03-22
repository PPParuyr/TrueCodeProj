using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueCodeTestProj.Services
{
    internal interface IUserService
    {
        Task<User> GetUserByIdAndDomainAsync(Guid userId, string domain);
        Task<IEnumerable<User>> GetUsersByDomainAsync(string domain, int page, int pageSize);
        Task<IEnumerable<User>> GetUsersByTagAndDomainAsync(string tagValue, string domain);
    }
}
