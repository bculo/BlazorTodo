using System;
using System.Collections.Generic;
using TodoBlazor.Domain.Common;

namespace TodoBlazor.Domain.Entites
{
    public class TodoList : AuditableEntity
    {
        public Guid Id { get; set; }
        public virtual ICollection<TodoItem> TodoItems { get; set; }
    }
}
