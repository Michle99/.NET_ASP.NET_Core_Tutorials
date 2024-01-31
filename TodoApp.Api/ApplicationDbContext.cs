// ApplicationDbContext.cs

namespace TodContext;

using Microsoft.EntityFrameworkCore;
using Todo;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<TodoItem> TodoItems { get; set; }
}
