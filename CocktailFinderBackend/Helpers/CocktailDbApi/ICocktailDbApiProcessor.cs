using CocktailDataAccess.Models;
using CocktailFinderBackend.Models;

namespace CocktailFinderBackend.Helpers.CocktailDbApi
{
    public interface ICocktailDbApiProcessor
    {
        Cocktail getCocktailById(int id);
        List<SearchingModel> getCocktailsByIngredientName(string name);
        Cocktail getRandomCocktail();
    }
}