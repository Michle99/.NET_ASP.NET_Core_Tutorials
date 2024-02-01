// TodoContext.cs

using Microsoft.EntityFrameworkCore;

using TodoApp.Models;

public class TodoContext : DbContext
{
    public DbSet<TodoItem> TodoItems { get; set; }

    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Specify the data type of the primary key
        modelBuilder.Entity<TodoItem>()
            .Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .HasColumnType("INTEGER");

        base.OnModelCreating(modelBuilder);
    }
}
