using AutoMapper;
using CocktailDataAccess.DataAccess;
using CocktailDataAccess.Models;
using CocktailFinderBackend.Common.Favourites.Commands;
using CocktailFinderBackend.Helpers.CocktailDbApi;
using MediatR;

namespace CocktailFinderBackend.Common.Favourites.Handlers
{
    public class AddFavouriteHandler : CocktailHandlerBase, IRequestHandler<AddFavouriteCommand>
    {
        public AddFavouriteHandler(IMediator mediator, IMapper mapper, ICocktailDbApiProcessor cocktailDbProcessor, CocktailDbContext context) : base(mediator, mapper, cocktailDbProcessor, context)
        {
        }

        public async Task<Unit> Handle(AddFavouriteCommand request, CancellationToken cancellationToken)
        {
            var cocktailVM = request.Cocktail;
            var cocktail = _mapper.Map<Cocktail>(cocktailVM);
            try
            {
                if (!_context.Cocktails.Any(c => c.Id == cocktail.Id))
                {
                    _context.Cocktails.Add(cocktail);
                    await _context.SaveChangesAsync();
                    //_logger.LogInformation($"{cocktail.Name} added");
                    return Unit.Value;
                }
                else
                {
                    //_logger.LogWarning($"{cocktail.Name} already exists!!!");
                    return Unit.Value;
                }
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, ex.Message);
                return Unit.Value;
            }
        }
    }
}
