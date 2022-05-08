using AutoMapper;
using CocktailDataAccess.DataAccess;
using CocktailDataAccess.Models;
using CocktailFinderBackend.Common.Favourites.Commands;
using CocktailFinderBackend.Helpers.CocktailDbApi;
using CocktailFinderBackend.Helpers.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CocktailFinderBackend.Common.Favourites.Handlers
{
    public class EditFavouriteHandler : CocktailHandlerBase, IRequestHandler<EditFavouriteCommand>
    {
        public EditFavouriteHandler(IMediator mediator, IMapper mapper, ICocktailDbApiProcessor cocktailDbProcessor, CocktailDbContext context) : base(mediator, mapper, cocktailDbProcessor, context)
        {
        }

        public async Task<Unit> Handle(EditFavouriteCommand request, CancellationToken cancellationToken)
        {
            var editedCocktail = request.CocktailVM;
            try
            {
                Cocktail cocktail = _context.Cocktails.Include(c => c.Ingredients).FirstOrDefault(c => c.Id == editedCocktail.Id);
                if (cocktail == null) throw new NullReferenceException();

                cocktail.Name = editedCocktail.Name;
                cocktail.Instructions = editedCocktail.Instructions;
                cocktail.ImageUrl = editedCocktail.ImageUrl;
                //_context.Ingredients.Re
                for (int i = 0; i < cocktail.Ingredients.Count; i++)
                {
                    try
                    {
                        cocktail.Ingredients[i] = editedCocktail.Ingredients[i];
                    }
                    catch { break; }
                }

                _context.Entry(cocktail).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                //_logger.LogInformation($"{editedCocktail.Name} edited");
                return Unit.Value;
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, ex.Message);
                throw new NotFoundException();
            }
        }
    }
}
