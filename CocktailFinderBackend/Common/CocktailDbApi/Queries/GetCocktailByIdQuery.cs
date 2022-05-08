using CocktailFinderBackend.Models;
using MediatR;

namespace CocktailFinderBackend.Common.Queries
{
    public class GetCocktailByIdQuery : IRequest<CocktailVM>
    {
        public GetCocktailByIdQuery(int Id)
        {
            this.Id = Id;
        }

        public int Id { get; }
    }
}
