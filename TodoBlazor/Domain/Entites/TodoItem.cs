using System;
using TodoBlazor.Domain.Common;
using TodoBlazor.Domain.Enums;

namespace TodoBlazor.Domain.Entites
{
    public class TodoItem : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public bool Done { get; set; }
        public Priority Priority { get; set; }
        public Guid TodoListId { get; set; }
        public virtual TodoList TodoList { get; set; }
    }
}
