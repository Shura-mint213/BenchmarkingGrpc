using Dictionary.MSSQLContext;
using GrpcService.Services;
using Microsoft.EntityFrameworkCore;
using Repositories.MSSQL.Extensions;
using Shared.Models;
using Shared.Statics;

var builder = WebApplication.CreateBuilder(args);

LoadingSettings(builder.Configuration);

builder.Services.AddGrpc();

//builder.Services.Configure<MongoSettings>(options =>
//{
//    options.ConnectionString = builder.Configuration.GetSection("MongoConnection:ConnectionString")?.Value ??
//        throw new ArgumentNullException("ConnectionString");
//    options.Database = builder.Configuration.GetValue("Database")?.Value ??
//        throw new ArgumentNullException("Database"); ;
//});

//if (connectionString is null)
//    throw new InvalidOperationException("Connection string not found.");

builder.Services.AddDictionaryContext(DatabaseSettings.ConnectionStringMSSQL);
builder.Services.AddRepositoriesMSSQL();


// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<CountryService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();

void LoadingSettings(IConfiguration conf)
{
    DatabaseSettings.ConnectionStringMSSQL =
        builder.Configuration.GetConnectionString("DictionaryConnectionMSSQL") ??
        throw new ArgumentNullException("DictionaryConnectionMSSQL");
    DatabaseSettings.ConnectionStringMongoDB =
        builder.Configuration.GetConnectionString("DictionaryConnectionMongoDB") ??
        throw new ArgumentNullException("DictionaryConnectionMongoDB");
    DatabaseSettings.Database =
        builder.Configuration["Database"] ??
        throw new ArgumentNullException("Database");
}