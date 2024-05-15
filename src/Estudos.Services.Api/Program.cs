using Estudos.CrossCutting;
using Estudos.CrossCutting.IoC.Settings;
using Estudos.Data.Context;
using Estudos.Domain.Entities;
using Estudos.Domain.Validator;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

builder.Services.Configure<WebSettings>(options => configuration.Bind(options));
WebSettings webSettings = configuration.Get<WebSettings>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDependencies();

builder.Services.AddDbContext<DbContext, AppDbContext>(options =>
{
    if (env.EnvironmentName == "inMemoryDb")
        options.UseInMemoryDatabase("Estudos");

    else if (env.EnvironmentName == "Development")
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                     b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));

});





var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();
