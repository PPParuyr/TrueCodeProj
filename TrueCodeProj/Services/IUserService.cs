using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueCodeProj.Models;

namespace TrueCodeTestProj.Services
{
    internal interface IUserService
    {
        Task<User> GetUserByIdAndDomainAsync(Guid userId, string domain);
        Task<List<User>> GetUsersByDomainAsync(string domain, int page, int pageSize);
        Task<List<User>> GetUsersByTagAndDomainAsync(string tagValue, string domain);
    }
}
