using GrpcTesting.Services;
using Microsoft.EntityFrameworkCore;
using Northwind.DataContext;
using Repositories.Extensions;
using Shared.Statics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();

string? connectionString = DatabaseSettings.ConnectionString ??
    builder.Configuration.GetConnectionString("NorthwindConnection");

if (connectionString is null)
    throw new InvalidOperationException("Connection string not found.");

builder.Services.AddNorthwindContext(connectionString);
builder.Services.AddRepositories();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<OrdersService>();
app.MapGet("/", () => "Не удалось найти конечную точку, к которой шел запрос; возможно, она не была зарегистрирована на gRPC сервере.");

app.Run();
