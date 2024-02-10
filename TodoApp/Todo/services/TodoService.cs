// TodoService.cs

using System.Net.Http.Json;
using TodoApp.Models;
using System.Threading.Tasks;

namespace TodoApp.Service;

public interface ITodoService
{
   Task<List<TodoItem>> GetTodoItems();
    Task<TodoItem> GetTodoItem(int id);
    Task<TodoItem> AddTodoItem(TodoItem item);
    Task<TodoItem> UpdateTodoItem(TodoItem item);
    Task DeleteTodoItem(int id);
}

public class TodoService : ITodoService
{
    private List<TodoItem> todoItems = new List<TodoItem>();
    private readonly HttpClient _httpClient;

    public TodoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<TodoItem>> GetTodoItems()
    {
        return await _httpClient.GetFromJsonAsync<List<TodoItem>>("api/todo");
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

    public async Task<TodoItem> UpdateTodoItem(TodoItem item)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/todo/{item.Id}", item);
        return await response.Content.ReadFromJsonAsync<TodoItem>();
    }

    public async Task DeleteTodoItem(int id)
    {
        await _httpClient.DeleteAsync($"api/todo/{id}");
    }
}
