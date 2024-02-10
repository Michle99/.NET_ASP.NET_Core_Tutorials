using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services to the container.
builder.Services.AddDbContext<TodoContext>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("TodoDatabase"))
);

builder.Services.AddControllers();
builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins",
            builder => builder
                .WithOrigins("*")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
            );
        }
);




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseRouting();

app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();