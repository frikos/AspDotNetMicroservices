using Basket.api.Repositories;

var builder = WebApplication.CreateBuilder(args);
 ConfigurationManager Configuration =builder.Configuration ;
// Add services to the container.
builder.Services.AddStackExchangeRedisCache(options =>
    options.Configuration=Configuration.GetValue<string>("CacheSettigs:ConnectionString")
);
builder.Services.AddScoped<IBasketRepository, BasketRepository>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
