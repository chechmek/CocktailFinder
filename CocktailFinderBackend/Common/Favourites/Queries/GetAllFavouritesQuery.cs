using CocktailFinderBackend.Models;
using MediatR;

namespace CocktailFinderBackend.Common.Favourites.Queries
{
    public class GetAllFavouritesQuery : IRequest<List<CocktailVM>>
    {
    }
}
