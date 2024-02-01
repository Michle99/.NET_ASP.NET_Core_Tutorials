// TodoService.cs

using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TodoApp.Models;

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
    private readonly HttpClient _httpClient;

    public TodoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<TodoItem[]> GetTodoItems()
    {
        return await _httpClient.GetFromJsonAsync<TodoItem[]>("api/Todo");
    }

    public async Task<TodoItem> GetTodoItem(int id)
    {
        return await _httpClient.GetFromJsonAsync<TodoItem>($"api/Todo/{id}");
    }

    public async Task<TodoItem> AddTodoItem(TodoItem item)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Todo", item);
        return await response.Content.ReadFromJsonAsync<TodoItem>();
    }

    public async Task UpdateTodoItem(int id, TodoItem item)
    {
        await _httpClient.PutAsJsonAsync($"api/Todo/{id}", item);
    }

    public async Task DeleteTodoItem(int id)
    {
        await _httpClient.DeleteAsync($"api/Todo/{id}");
    }
}
