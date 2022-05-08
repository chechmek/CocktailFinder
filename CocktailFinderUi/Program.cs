using CocktailDataAccess.DataAccess;
using CocktailFinderBackend;
using CocktailFinderBackend.CocktailDbApi;
using CocktailFinderBackend.Common;
using CocktailFinderBackend.Common.CocktailDbApi;
using CocktailFinderBackend.Common.CocktailDbApi.Handlers;
using CocktailFinderBackend.Helpers.CocktailDbApi;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<ICocktailDbApiProcessor, CocktailDbApiProcessor>();
builder.Services.AddAutoMapper(typeof(BackendAssembly));
var assembly = AppDomain.CurrentDomain.Load("CocktailFinderBackend");
builder.Services.AddMediatR(assembly);
builder.Services.AddDbContext<CocktailDbContext>(options =>
{
    string ConnectionString = builder.Configuration.GetConnectionString("Default");
    options.UseSqlServer(ConnectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Search}/{action=Index}/{id?}");

app.Run();
