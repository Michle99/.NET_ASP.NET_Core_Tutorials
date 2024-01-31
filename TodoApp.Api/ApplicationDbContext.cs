// ApplicationDbContext.cs

namespace TodContext;

using Microsoft.EntityFrameworkCore;
using Todo;

public class ApplicationDbContext : DbContext
{
    public DbSet<TodoItem> TodoItems { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
