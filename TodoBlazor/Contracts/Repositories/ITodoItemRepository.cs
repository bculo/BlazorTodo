using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoBlazor.Domain.Entites;

namespace TodoBlazor.Contracts.Repositories
{
    public interface ITodoItemRepository : IRepository<TodoItem>
    {
    }
}
