using Basket.Api.Mapping;
using Basket.Api.Repositories;
using Basket.Api.Services;
using Discount.Grpc.Protos;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IDiscountGrpcService, DiscountGrpcService>();

#region Config Redis

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetValue<string>("CacheSettings:ConnectionString");
});
#endregion Config Redis

#region Config Grpc

builder.Services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>(options =>
{
    options.Address = new Uri(builder.Configuration["GrpcSettings:DiscountUrl"]);
});
#endregion Config Grpc

#region Config MassTransit-RabbitMq

builder.Services.AddMassTransit(config =>
{
    config.UsingRabbitMq((ctx, conf) =>
    {
        conf.Host(builder.Configuration["EventBusSettings:HostAddressRabbitMq"]);
    });
});
builder.Services.AddMassTransitHostedService();

#endregion Config MassTransit-RabbitMq

builder.Services.AddAutoMapper(typeof(MappingProfile));

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
