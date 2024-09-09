using GrpcTesting.Services;
using Microsoft.EntityFrameworkCore;
using Northwind.DataContext;
using Repositories.MSSQL.Extensions;
using Shared.Models;
using Shared.Statics;

var builder = WebApplication.CreateBuilder(args);

LoadingSettings(builder.Configuration);

builder.Services.AddGrpc();

//string? connectionString = DatabaseSettings.ConnectionString ??
//    builder.Configuration.GetConnectionString("NorthwindConnection");


//builder.Services.Configure<MongoSettings>(options =>
//{
//    options.ConnectionString = builder.Configuration.GetSection("MongoConnection:ConnectionString")?.Value ??
//        throw new ArgumentNullException("ConnectionString");
//    options.Database = builder.Configuration.GetSection("MongoConnection:Database")?.Value ??
//        throw new ArgumentNullException("Database"); ;
//});

//if (connectionString is null)
//    throw new InvalidOperationException("Connection string not found.");

builder.Services.AddNorthwindContext(DatabaseSettings.ConnectionStringMSSQL);
builder.Services.AddRepositoriesMSSQL();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<OrdersService>();
app.MapGet("/", () => "�� ������� ����� �������� �����, � ������� ��� ������; ��������, ��� �� ���� ���������������� �� gRPC �������.");

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