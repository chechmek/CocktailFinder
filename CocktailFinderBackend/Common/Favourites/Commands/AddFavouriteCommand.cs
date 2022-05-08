using CocktailFinderBackend.Models;
using MediatR;

namespace CocktailFinderBackend.Common.Favourites.Commands
{
    public class AddFavouriteCommand : IRequest
    {
        public AddFavouriteCommand(CocktailVM cocktail)
        {
            Cocktail = cocktail;
        }

        public CocktailVM Cocktail { get; }
    }
}
