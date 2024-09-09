using Shared.Statics;
using Dictionary.MSSQLContext;
using Microsoft.Extensions.Configuration;
using Shared.Models;
using Repositories.MSSQL.Extensions;
using Repositories.MongoDB.Extensions;
using MongoDB.Driver.Core.Configuration;

var builder = WebApplication.CreateBuilder(args);

LoadingSettings(builder.Configuration);
// Add services to the container.


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


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options => {
    // Фикс ошики "Невозможно использовать schemaId. Тот же schemaId уже используется для типа"
    options.CustomSchemaIds(type => type.ToString());
});

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