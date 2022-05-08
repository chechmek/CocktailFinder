using AutoMapper;
using CocktailDataAccess.DataAccess;
using CocktailFinderBackend.Common.Favourites.Queries;
using CocktailFinderBackend.Helpers.CocktailDbApi;
using CocktailFinderBackend.Helpers.Exceptions;
using CocktailFinderBackend.Models;
using MediatR;

namespace CocktailFinderBackend.Common.Favourites.Handlers
{
    public class GetAllFavouritesHandler : CocktailHandlerBase, IRequestHandler<GetAllFavouritesQuery, List<CocktailVM>>
    {
        public GetAllFavouritesHandler(IMediator mediator, IMapper mapper, ICocktailDbApiProcessor cocktailDbProcessor, CocktailDbContext context) : base(mediator, mapper, cocktailDbProcessor, context)
        {
        }

        public async Task<List<CocktailVM>> Handle(GetAllFavouritesQuery request, CancellationToken cancellationToken)
        {
            var cocktails = _context.Cocktails.ToList() ?? throw new NotFoundException();
            var cocktailsVM = _mapper.Map<List<CocktailVM>>(cocktails);
            return cocktailsVM;
        }
    }
}
