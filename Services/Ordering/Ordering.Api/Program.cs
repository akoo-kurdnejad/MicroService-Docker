using EventBus.Messages.Common;
using MassTransit;
using Ordering.ApplicationService.EventBusConsumers;
using Ordering.DataAccess.EF.DBContext;
using Ordering.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationDependency(builder.Configuration);

#region Config MassTransit-RabbitMq

builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<BasketCheckoutConsumer>();
    config.UsingRabbitMq((ctx, conf) =>
    {
        conf.Host(builder.Configuration["EventBusSettings:HostAddressRabbitMq"]);
        conf.ReceiveEndpoint(EventBusConstans.BasketCheckoutQueue, c =>
        {
            c.ConfigureConsumer<BasketCheckoutConsumer>(ctx);
        });
    });
});

builder.Services.AddMassTransitHostedService();
builder.Services.AddScoped<BasketCheckoutConsumer>();

#endregion Config MassTransit-RabbitMq

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.InitializeDatabase();
app.UseAuthorization();

app.MapControllers();

app.Run();
