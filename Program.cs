using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WatchApiBackend.Models;
using WatchApiBackend.Services;

var builder = WebApplication.CreateBuilder(args);

// Configure Database Settings
builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("DatabaseProperties"));

builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration["DatabaseProperties:ConnectionString"]));

builder.Services.AddSingleton(s =>
{
    var settings = s.GetRequiredService<IOptions<DatabaseSettings>>().Value;
    var client = s.GetRequiredService<IMongoClient>();
    return client.GetDatabase(settings.DatabaseName);
});

// Register Services
builder.Services.AddScoped<TeamService>();
builder.Services.AddScoped<ResponseLogService>();
builder.Services.AddScoped<EmailNotificationService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();