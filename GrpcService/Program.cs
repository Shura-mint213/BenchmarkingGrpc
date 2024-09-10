using Dictionary.MSSQLContext;
using GrpcService.Services;
using Microsoft.EntityFrameworkCore;
using Repositories.MSSQL.Extensions;
using Repositories.MongoDB.Extensions;
using Shared.Models;
using Shared.Statics;

var builder = WebApplication.CreateBuilder(args);

LoadingSettings(builder.Configuration);

builder.Services.AddGrpc();

builder.Services.Configure<MongoSettings>(options =>
{
    options.ConnectionString = DatabaseSettings.ConnectionStringMongoDB ??
        throw new ArgumentNullException("DictionaryConnectionMongoDB");
    options.Database = DatabaseSettings.Database ??
        throw new ArgumentNullException("Database"); ;
});


builder.Services.AddDictionaryContext(DatabaseSettings.ConnectionStringMSSQL!);
builder.Services.AddRepositoriesMSSQL();
builder.Services.AddRepositoriesMongo();


// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<CountriesService>();
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