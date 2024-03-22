using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueCodeTestProj.Services
{
    internal interface ITagService
    {
        Task<IEnumerable<Tag>> GetTagsByValueAndDomainAsync(string tagValue, string domain);
    }
}
