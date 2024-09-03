using GrpcTesting.Services;
using Microsoft.EntityFrameworkCore;
using Northwind.DataContext;
using Repositories.MsSql.Extensions;
using Shared.Models;
using Shared.Statics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();

string? connectionString = DatabaseSettings.ConnectionString ??
    builder.Configuration.GetConnectionString("NorthwindConnection");


builder.Services.Configure<MongoSettings>(options =>
{
    options.ConnectionString = builder.Configuration.GetSection("MongoConnection:ConnectionString")?.Value ??
        throw new ArgumentNullException("ConnectionString");
    options.Database = builder.Configuration.GetSection("MongoConnection:Database")?.Value ??
        throw new ArgumentNullException("Database"); ;
});

if (connectionString is null)
    throw new InvalidOperationException("Connection string not found.");

builder.Services.AddNorthwindContext(connectionString);
builder.Services.AddRepositoriesMsSql();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<OrdersService>();
app.MapGet("/", () => "Не удалось найти конечную точку, к которой шел запрос; возможно, она не была зарегистрирована на gRPC сервере.");

app.Run();
