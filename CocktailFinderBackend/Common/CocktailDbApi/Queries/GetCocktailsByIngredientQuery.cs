using CocktailFinderBackend.Models;
using MediatR;

namespace CocktailFinderBackend.Common.CocktailDbApi
{
    public class GetCocktailsByIngredientQuery : IRequest<List<SearchingModel>>
    {
        public GetCocktailsByIngredientQuery(string Ingredient)
        {
            this.Ingredient = Ingredient ?? throw new ArgumentNullException(nameof(Ingredient));
        }
        public string Ingredient { get; }
    }
}
