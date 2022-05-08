using CocktailDataAccess.Models;

namespace CocktailFinderBackend.Models
{
    public class CocktailVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Alcoholic { get; set; }
        public string Glass { get; set; }
        public string Instructions { get; set; }
        public string ImageUrl { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public bool InFavourites { get; set; }
    }
}
