using BookinfoCommon;
using BookinfoCommon.Interfaces;
using BookinfoCommon.Models;
using BookServiceInfo.Data;
using BookServiceInfo.Services;
using RedisManager;
using StackExchange.Redis;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddSingleton(sp =>
{
    int minute = builder.Configuration.GetSection("CacheSettings").GetValue<int>("InMemoryCachePeriod");
    return new InMemoryCache<BookInfo>(minute);
});

builder.Services.AddSingleton(sp =>
{
    var redisConfiguration = builder.Configuration.GetConnectionString("Redis");
    var redisConnection= ConnectionMultiplexer.Connect(redisConfiguration);
    int minute = builder.Configuration.GetSection("CacheSettings").GetValue<int>("RedisCachePeriod");
   
    return new RedisCacheService<BookInfo>(redisConnection, minute);
});
builder.Services.AddScoped<IBookInfoService, BookInfoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
