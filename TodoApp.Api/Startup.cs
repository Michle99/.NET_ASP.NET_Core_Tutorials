//* Startup.c

using Microsoft.EntityFrameworkCore;
namespace TodoApp.Backend;

public class Startup {
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<TodoContext>(opt => opt.UseSqlite("TodoList"));
        services.AddControllers();
    }
}
