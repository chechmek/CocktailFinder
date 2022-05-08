using CocktailFinderBackend.Models;
using MediatR;

namespace CocktailFinderBackend.Common.Queries
{
    public class GetRandomCocktailQuery : IRequest<CocktailVM>
    { 
    }
}
