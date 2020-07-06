using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using TodoBlazor.Contracts.Services;
using TodoBlazor.Domain.Common;
using TodoBlazor.Domain.Entites;

namespace TodoBlazor.Persistence
{
    public class TodoDbContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
    {
        private readonly ICurrentUserService _user;

        public TodoDbContext(DbContextOptions<TodoDbContext> options,
            ICurrentUserService user) 
            : base(options)
        {
            _user = user;
        }

        /// <summary>
        /// TodoItem table
        /// </summary>
        public DbSet<TodoItem> TodoItems { get; set; }

        /// <summary>
        /// TodoList table
        /// </summary>
        public DbSet<TodoList> TodoLists { get; set; }

        /// <summary>
        /// Fluent API entities configuration
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(TodoDbContext).Assembly);
            base.OnModelCreating(builder);
        }

        /// <summary>
        /// Overriden save async method
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _user.UserId;
                        entry.Entity.ModifiedBy = _user.UserId;
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.LastModified = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedBy = _user.UserId;
                        entry.Entity.LastModified = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
