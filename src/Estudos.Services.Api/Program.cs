using Estudos.CrossCutting;
using Estudos.CrossCutting.IoC.Settings;
using Estudos.Data.Context;
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
    //if (env.EnvironmentName == "inMemoryDb")
        options.UseInMemoryDatabase("Estudos");

    //else//if (env.EnvironmentName == "Sqlite")
    //options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"),
    //        b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));

        //else
        //options.UseNpgsql(configuration["ConnectionStrings:DefaultConnection"], o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
});





var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
