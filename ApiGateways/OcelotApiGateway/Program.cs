using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging")).ClearProviders().AddConsole().AddDebug();

builder.WebHost.ConfigureAppConfiguration((builderContext, config) =>
{
    config.AddJsonFile($"ocelot.{builderContext.HostingEnvironment.EnvironmentName}.json");
});

builder.Services.AddOcelot();
//builder.WebHost.ConfigureLogging(options =>
//{
//    options.AddConfiguration(builder.Configuration.GetSection("Logging"));
//    options.ClearProviders();
//    options.AddConsole();
//    options.AddDebug();
//});
var app = builder.Build();

app.UseOcelot().Wait();
app.MapGet("/", () => "Hello World!");

app.Run();
