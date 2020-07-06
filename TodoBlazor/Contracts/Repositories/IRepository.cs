using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoBlazor.Contracts.Repositories
{
    public interface IRepository<T> where T : class
    {
        ValueTask<T> GetById(object instanceId);
    }
}
