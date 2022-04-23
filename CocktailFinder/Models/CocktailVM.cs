using CocktailDataAccessLibrary.Models;

namespace CocktailFinder.Models
{
    public class CocktailVM
    {
        public Cocktail Cocktail { get; set; }
        public bool InFavourites { get; set; }
    }
}
