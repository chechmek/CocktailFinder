using MediatR;

namespace CocktailFinderBackend.Common.Favourites.Commands
{
    public class RemoveFavouriteCommand : IRequest
    {
        public RemoveFavouriteCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
