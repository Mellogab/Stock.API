using Stock.Core.Boundaries;
using Stock.Core.Services;
using Stock.Core.UseCases;
using Stock.Core;
using Stock.Infrastructure.Services;
using Stock.Presenters;
using Stock.Infrastructure.AutoMapper;
using MongoDB.Driver.Core.Configuration;
using Stock.Infrastructure.Repository;
using Stock.Core.Repository;
using Stock.Infrastructure.Respository;
using Stock.Core.UseCases.Adapters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IExtractStocksFromInternet, ExtractStocksFromInternet>();
builder.Services.AddSingleton<IHttpRequestService, HttpRequestService>();
builder.Services.AddSingleton<ICalculateCheapestStocks, CalculateCheapestStocks>();

//builder.Services.AddScoped<IOutputPort<CalculateCheapestStocksOutput>>();
builder.Services.AddScoped<DefaultPresenter<UseCaseResponseMessage>>();
builder.Services.AddScoped(typeof(DefaultPresenter<>), typeof(DefaultPresenter<>));

var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
IConfigurationRoot configuration = configurationBuilder.Build();

var connectionString = configuration["ConnectionStrings:MongoDb"];
var databaseName = configuration["ConnectionStrings:DatabaseName"];

builder.Services.AddSingleton<MongoDbContext>(opt => new MongoDbContext(connectionString, databaseName));
builder.Services.AddSingleton<IStockRepository, StockRepository>();
builder.Services.AddSingleton<ICheapestStockRepository, CheapestStockRepository>();


builder.Services.AddAutoMapper(mapper =>
{
    mapper.AddProfile<MappingProfile>();
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
