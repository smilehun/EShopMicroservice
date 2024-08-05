
var builder = WebApplication.CreateBuilder(args);

//add service to the container
builder.Services.AddCarter();

var assembly = typeof(Program).Assembly;
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});


var app = builder.Build();

//configure the http request pipeline

app.MapCarter();
app.Run();
