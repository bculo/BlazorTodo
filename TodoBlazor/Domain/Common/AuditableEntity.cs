using System;

namespace TodoBlazor.Domain.Common
{
    public abstract class AuditableEntity
    {
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
    }
}
