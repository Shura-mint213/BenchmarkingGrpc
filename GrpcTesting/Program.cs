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
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
