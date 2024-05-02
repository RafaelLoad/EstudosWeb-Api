using Estudos.CrossCutting;
using Estudos.Data.Context;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

IWebHostEnvironment env = builder.Environment;
IConfiguration configuration  = new ConfigurationBuilder()
    .SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.Json", optional: false)
    .Build();

var logger = new LoggerConfiguration()
     .ReadFrom.Configuration(configuration)
     .Enrich.FromLogContext()
     .CreateLogger();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDependencies();

builder.Services.AddDbContext<DbContext, Context>(options =>
{
    if (env.EnvironmentName == "inMemoryDb")
        options.UseInMemoryDatabase("Estudos");

    //else
        //options.UseNpgsql(configuration["Database:ConnectionString"], o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));//ajustar
});

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
