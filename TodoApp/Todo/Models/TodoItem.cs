
namespace TodoApp.Models;

public class TodoItem
{
    public long Id { get; set; }
    public required string Title { get; set; }
    public bool IsCompleted { get; set; }
}