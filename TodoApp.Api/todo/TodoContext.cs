// TodoContext.cs

using Microsoft.EntityFrameworkCore;

using TodoApp.Models;

public class TodoContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public TodoContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public DbSet<TodoItem> TodoItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        //* Connect to sqlite database
        options.UseSqlite(Configuration.GetConnectionString("TodoDatabase"));
    }
}
