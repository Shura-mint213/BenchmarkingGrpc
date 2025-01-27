using Shared.Statics;
using Northwind.DataContext;
using Repositories.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string? connectionString = DatabaseSettings.ConnectionString ??
    builder.Configuration.GetConnectionString("NorthwindConnection");

if (connectionString is null)
    throw new InvalidOperationException("Connection string not found.");

builder.Services.AddNorthwindContext(connectionString);
builder.Services.AddRepositories();

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
