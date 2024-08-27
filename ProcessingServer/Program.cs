using ProcessingServer.Extensions;
using ProcessingServer.Shared.Statics;

var builder = WebApplication.CreateBuilder(args);

LoadingSettings(builder.Configuration);
// Add services to the container.

builder.Services.ConfigureHttpClientServices();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

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
    SettingsHttpClients.NameDataServer = conf["NameDataServer"] ??
        throw new ArgumentNullException("NameDataServer");
    SettingsHttpClients.NameGrpcTesting = conf["NameGrpcTesting"] ??
        throw new ArgumentNullException("NameGrpcTesting");
    SettingsHttpClients.DataServerUrl = conf["DataServerUrl"] ?? 
        throw new ArgumentNullException("DataServerUrl");
    SettingsHttpClients.GrpcTestingUrl = conf["GrpcTestingUrl"] ??
        throw new ArgumentNullException("GrpcTestingUrl");
}