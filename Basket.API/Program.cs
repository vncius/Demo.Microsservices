using Basket.API.Controllers;
using Basket.API.Repositories;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

var connectionRedis = builder.Configuration.GetValue<string>("CacheSettings:ConnectionString");

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddStackExchangeRedisCache(opt => opt.Configuration = connectionRedis);

builder.Services.AddScoped<IBasketRepository, BasketRepository>();

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
