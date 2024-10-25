using BookinfoCommon;
using BookinfoCommon.Interfaces;
using BookinfoCommon.Models;
using BookServiceInfo.Data;
using BookServiceInfo.Services;
using MassTransit;
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
    var configuration = sp.GetRequiredService<IConfiguration>();


    var inMemoryCachePeriod = int.Parse(
        Environment.GetEnvironmentVariable("CACHE_INMEMORY_PERIOD") ?? configuration["CacheSettings:InMemoryCachePeriod"]
    );
    Console.WriteLine($"inMemoryCachePeriod:{inMemoryCachePeriod}");
    //int minute = builder.Configuration.GetSection("CacheSettings").GetValue<int>("InMemoryCachePeriod");
    return new InMemoryCache<BookInfo>(inMemoryCachePeriod);
});

builder.Services.AddSingleton(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var redisConfiguration = builder.Configuration.GetConnectionString("Redis");
    var redisConnection = ConnectionMultiplexer.Connect(redisConfiguration);
    //int minute = builder.Configuration.GetSection("CacheSettings").GetValue<int>("RedisCachePeriod");
    var redisCachePeriod = int.Parse(Environment.GetEnvironmentVariable("CACHE_REDIS_PERIOD") ?? configuration["CacheSettings:RedisCachePeriod"]);
    Console.WriteLine($"redisCachePeriod:{redisCachePeriod}");
    return new RedisCacheService<BookInfo>(redisConnection, redisCachePeriod);
});

builder.Services.AddScoped<IBookInfoService, BookInfoService>();
builder.Services.AddMassTransit(x =>
{
    // Add the consumer for BookInfo changes
    x.AddConsumer<BookInfoChangedConsumer>();

    // Configure RabbitMQ
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("book-info-change-queue", ep =>
        {
            ep.ConfigureConsumer<BookInfoChangedConsumer>(context);
        });
    });
});

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
