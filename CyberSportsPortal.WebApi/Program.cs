using CyberSportsPortal.Core;
using CyberSportsPortal.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Получаем настройки и строим строку подключения
var dbSettings = builder.Configuration.GetRequiredSection(nameof(DbSettings)).Get<DbSettings>();
if (dbSettings == null)
{
    throw new InvalidOperationException("DbSettings section is missing in configuration");
}

var connectionString = $"Host={dbSettings.Host};Port={dbSettings.Port};Database={dbSettings.DbName};Username={dbSettings.User};Password={dbSettings.Password}";

Console.WriteLine($"Connecting to: Host={dbSettings.Host}, Port={dbSettings.Port}, Database={dbSettings.DbName}");

// Регистрируем DbContext
builder.Services.AddDbContext<CyberSportsContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddBusinessLogic();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyAllowSpecificOrigins",
                      policy =>
                      {
                          policy
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                      });
});

var app = builder.Build();

// Выполняем миграции
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<CyberSportsContext>();
    try
    {
        context.Database.Migrate();
        Console.WriteLine("Database migration completed successfully");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error during migration: {ex.Message}");
        throw;
    }
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("MyAllowSpecificOrigins");
app.UseAuthorization();
app.MapControllers();
app.Run();