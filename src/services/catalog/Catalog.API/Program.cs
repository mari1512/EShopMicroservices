
using BuildingBlocks.Behaviors;
using FluentValidation;

var assembly = typeof(Program).Assembly;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidatorBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddMarten(opt =>
{
    opt.Connection(builder.Configuration.GetConnectionString("db"));
}).UseLightweightSessions();

builder.Services.AddCarter();

var app = builder.Build();

app.MapCarter();

app.MapGet("/", () => "Hello World!");

app.Run();
