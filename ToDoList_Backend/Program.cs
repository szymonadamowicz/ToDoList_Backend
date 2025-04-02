using to_do_list.Data;
using ToDoList_Backend.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
        policy
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins(
                "http://localhost:3000",
                       "https://todolistfrontend-dsnwucuma-szymons-projects-1e0e4c1e.vercel.app",
                       "https://todolistfrontend-eta.vercel.app"
            )
    );
});

builder.Services.AddControllers();
builder.Services.AddSingleton<TaskService>();
builder.Services.AddSingleton<ThemeService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowFrontend");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
app.Urls.Add($"http://*:{port}");

app.Run();
