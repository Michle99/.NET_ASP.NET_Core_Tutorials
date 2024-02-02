// TodoService.cs

using System.Net.Http.Json;
using TodoApp.Models;

namespace TodoApp.Service;

public interface ITodoService
{
    Task<TodoItem[]> GetTodoItems();
    Task<TodoItem> GetTodoItem(int id);
    Task<TodoItem> AddTodoItem(TodoItem item);
    Task UpdateTodoItem(int id, TodoItem item);
    Task DeleteTodoItem(int id);
}

public class TodoService : ITodoService
{
    private List<TodoItem> todoItems = new List<TodoItem>();

    public async Task<TodoItem[]> GetTodoItems()
    {
        return await _httpClient.GetFromJsonAsync<TodoItem[]>("api/todo");
    }

    public async Task<TodoItem> GetTodoItem(int id)
    {
        return await _httpClient.GetFromJsonAsync<TodoItem>($"api/todo/{id}");
    }

    public async Task<TodoItem> AddTodoItem(TodoItem item)
    {
        var response = await _httpClient.PostAsJsonAsync("api/todo", item);
        return await response.Content.ReadFromJsonAsync<TodoItem>();
    }

    public async Task UpdateTodoItem(int id, TodoItem item)
    {
        await _httpClient.PutAsJsonAsync($"api/todo/{id}", item);
    }

    public async Task DeleteTodoItem(int id)
    {
        await _httpClient.DeleteAsync($"api/todo/{id}");
    }
}
