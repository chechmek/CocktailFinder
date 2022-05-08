using AutoMapper;
using CocktailDataAccess.DataAccess;
using CocktailDataAccess.Models;
using CocktailFinderBackend.Common.Queries;
using CocktailFinderBackend.Helpers.CocktailDbApi;
using CocktailFinderBackend.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CocktailFinderBackend.Common.CocktailDbApi.Handlers
{
    public class GetCocktailByIdHandler : CocktailHandlerBase, IRequestHandler<GetCocktailByIdQuery, CocktailVM>
    {
        public GetCocktailByIdHandler(IMediator mediator, IMapper mapper, ICocktailDbApiProcessor cocktailDbProcessor, CocktailDbContext context) : base(mediator, mapper, cocktailDbProcessor, context)
        {
        }

        public async Task<CocktailVM> Handle(GetCocktailByIdQuery request, CancellationToken cancellationToken)
        {
            int id = request.Id;
            Cocktail cocktail = new Cocktail();
            try
            {
                //Check if it is in favourites 
                if (_context.Cocktails.Any(c => c.Id == id))
                {
                    cocktail = _context.Cocktails.Include(c => c.Ingredients).FirstOrDefault(c => c.Id == id);
                    if (cocktail is not null)
                    {
                        cocktail.Ingredients.ForEach((i) =>
                        {
                            i.Id = 0;
                            i.Cocktails.Clear();
                        });
                    }
                }
                else
                {
                    //Call api for the cocktail by id
                    cocktail = _cocktailApiProcessor.getCocktailById(id);
                }
                var cocktailVM = _mapper.Map<CocktailVM>(cocktail);
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
