using Estudos.CrossCutting;
using Estudos.CrossCutting.IoC.Settings;
using Estudos.Data.Context;
using Estudos.Domain.Entities;
using Estudos.Domain.Validator;
using Estudos.Services.Api.Services;
using Estudos.Services.Config;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;
using System.Text;

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


var jwtSection = configuration.GetSection("Jwt");
var jwtOptions = jwtSection.Get<JwtBearerTokenServiceOptions>();
builder.Services.Configure<JwtBearerTokenServiceOptions>(jwtSection);

builder.Services.AddSingleton<IJwtBearerTokenService, JwtBearerTokenService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDependencies();
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ClienteValidator>());

builder.Services.AddDbContext<DbContext, AppDbContext>(options =>
{
    if (env.EnvironmentName == "inMemoryDb")
        options.UseInMemoryDatabase("Estudos");

    else if (env.EnvironmentName == "Development")
        options.UseSqlServer(webSettings.ConnectionStrings.DefaultConnection,
                     b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));

});

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Estudos Api",
        Version = "v1"
    });

    option.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidIssuer = jwtOptions.Issuer,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOptions.Key)),
    };
});


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.RoutePrefix = "swagger";
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Demo JWT Api");
});
app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();

