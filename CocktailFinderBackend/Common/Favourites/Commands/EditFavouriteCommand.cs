using CocktailFinderBackend.Models;
using MediatR;

namespace CocktailFinderBackend.Common.Favourites.Commands
{
    public class EditFavouriteCommand : IRequest
    {
        public EditFavouriteCommand(CocktailVM cocktailVM)
        {
            CocktailVM = cocktailVM;
        }

        public CocktailVM CocktailVM { get; }
    }
}
