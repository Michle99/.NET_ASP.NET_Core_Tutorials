// TodoService.cs

using System.Net.Http.Json;
using TodoApp.Models;

namespace TodoApp.Service;

public interface ITodoService
{
    List<TodoItem> GetTodoItems();
    TodoItem? GetTodoItem(int id);
    TodoItem AddTodoItem(TodoItem item);
    TodoItem UpdateTodoItem(TodoItem item);
    void DeleteTodoItem(int id);
}

public class TodoService : ITodoService
{
    private List<TodoItem> todoItems = new List<TodoItem>();

    public List<TodoItem> GetTodoItems()
    {
        return todoItems;
    }

    public TodoItem? GetTodoItem(int id)
    {
        return todoItems.Find(item => item.Id == id);
    }

    public TodoItem AddTodoItem(TodoItem item)
    {
       item.Id = todoItems.Count + 1;
       todoItems.Add(item);
       return item;
    }

    public TodoItem UpdateTodoItem(TodoItem updatedItem)
    {
        var existingItem = todoItems.Find(item => item.Id == updatedItem.Id);
        if (existingItem != null)
        {
            existingItem.Title = updatedItem.Title;
            existingItem.IsCompleted = updatedItem.IsCompleted;
        } 
        return updatedItem;
    }

    public void DeleteTodoItem(int id)
    {
        todoItems.RemoveAll(item => item.Id == id);
    }
}
