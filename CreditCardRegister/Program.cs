using CreditCardRegister.API;
using Serilog;



var builder = WebApplication.CreateBuilder(args);


Log.Logger = new LoggerConfiguration()
            .ReadFrom.C(builder.Configuration)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.File("../log/Application_.log", rollingInterval: RollingInterval.Day)
            .CreateLogger();

var logger = Log.Logger;
logger.Information("Initializing application");


// Add services to the container.
DependencyInjection.InjectProcessorServices(builder.Services, builder.Configuration, logger);
DependencyInjection.InjectProcessorServices(builder.Services, builder.Configuration, logger);
DependencyInjection.InjectProcessorServices(builder.Services, builder.Configuration, logger);
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
