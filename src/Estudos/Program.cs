using Estudos.Api.ApiServices;
using Estudos.Application.Interfaces.ApiServices;
using Estudos.Web.Middleware;

var builder = WebApplication.CreateBuilder(args);

IWebHostEnvironment env = builder.Environment;

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.Json", optional: false)
    .Build();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddAntiforgery(o => o.SuppressXFrameOptionsHeader = true);

builder.Services.AddScoped<IAutenticacaoApiService, AutenticacaoApiService>();
builder.Services.RegisterHttpServices(configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllers(); // Adiciona o suporte para controllers MVC
});
app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Login}/{action=Index}/{id?}");
});

app.Run();