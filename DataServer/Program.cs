using Shared.Statics;
using Northwind.DataContext;
using Microsoft.Extensions.Configuration;
using Shared.Models;
using Repositories.MsSql.Extensions;
using Repositories.Mongo.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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
builder.Services.AddRepositoriesMongo();


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
