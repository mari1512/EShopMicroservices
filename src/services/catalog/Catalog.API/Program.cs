
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddMarten(opt =>
{
    opt.Connection(builder.Configuration.GetConnectionString("db"));
}).UseLightweightSessions();
var app = builder.Build();

app.MapCarter();

app.MapGet("/", () => "Hello World!");

app.Run();
