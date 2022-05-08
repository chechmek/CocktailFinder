using AutoMapper;
using CocktailDataAccess.DataAccess;
using CocktailDataAccess.Models;
using CocktailFinderBackend.Common.Favourites.Commands;
using CocktailFinderBackend.Helpers.CocktailDbApi;
using CocktailFinderBackend.Helpers.Exceptions;
using MediatR;

namespace CocktailFinderBackend.Common.Favourites.Handlers
{
    public class RemoveFavouriteHandler : CocktailHandlerBase, IRequestHandler<RemoveFavouriteCommand>
    {
        public RemoveFavouriteHandler(IMediator mediator, IMapper mapper, ICocktailDbApiProcessor cocktailDbProcessor, CocktailDbContext context) : base(mediator, mapper, cocktailDbProcessor, context)
        {
        }

        public async Task<Unit> Handle(RemoveFavouriteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _context.Cocktails.Remove(new Cocktail() { Id = request.Id });
                await _context.SaveChangesAsync();
                //_logger.LogInformation($"{request.Id} removed");
                return Unit.Value;
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, ex.Message);
                throw new NotFoundException(request.Id.ToString());
            }
        }
    }
}
