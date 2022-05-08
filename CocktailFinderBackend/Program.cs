using CocktailDataAccess.DataAccess;
using CocktailFinderBackend.Helpers.Mapping;
using CocktailFinderBackend.CocktailDbApi;
using Microsoft.EntityFrameworkCore;
using CocktailFinderBackend.Helpers.CocktailDbApi;
using CocktailFinderBackend;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddTransient<ICocktailDbApiProcessor, CocktailDbApiProcessor>();
//builder.Services.AddAutoMapper(typeof(MappingProfile));
//builder.Services.AddHttpClient();
//builder.Services.AddAutoMapper(cfg => {
//    cfg.ConfigureMapper();
//});
//builder.Services.AddDbContext<CocktailDbContext>(options =>
//{
//    string ConnectionString = builder.Configuration.GetConnectionString("Default");
//    options.UseSqlServer(ConnectionString);
//});

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
