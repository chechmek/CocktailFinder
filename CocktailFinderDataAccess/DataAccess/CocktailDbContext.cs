using CocktailDataAccess.Models;
using Microsoft.EntityFrameworkCore;


namespace CocktailDataAccess.DataAccess
{
    public class CocktailDbContext : DbContext
    {
        public CocktailDbContext(DbContextOptions options) : base(options) 
        {
            Database.EnsureCreated();
        }
        public DbSet<Cocktail> Cocktails { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
    }
}
