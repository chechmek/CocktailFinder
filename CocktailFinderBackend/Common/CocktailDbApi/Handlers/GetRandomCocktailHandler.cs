using AutoMapper;
using CocktailDataAccess.DataAccess;
using CocktailFinderBackend.Common.Queries;
using CocktailFinderBackend.Helpers.CocktailDbApi;
using CocktailFinderBackend.Models;
using MediatR;

namespace CocktailFinderBackend.Common.CocktailDbApi.Handlers
{
    public class GetRandomCocktailHandler : CocktailHandlerBase, IRequestHandler<GetRandomCocktailQuery, CocktailVM>
    {
        public GetRandomCocktailHandler(IMediator mediator, IMapper mapper, ICocktailDbApiProcessor cocktailDbProcessor, CocktailDbContext context) : base(mediator, mapper, cocktailDbProcessor, context)
        {
        }
        public async Task<CocktailVM> Handle(GetRandomCocktailQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var cocktail = _cocktailApiProcessor.getRandomCocktail();
                var cocktailVM = _mapper.Map<CocktailVM>(cocktail);
                cocktailVM.InFavourites = _context.Cocktails.Any(c => c.Id == cocktailVM.Id);
                return cocktailVM;
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, ex.Message);
                return null;
            }
        }
    }
}
