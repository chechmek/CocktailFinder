using CocktailFinderBackend.Common.Favourites.Commands;
using CocktailFinderBackend.Common.Favourites.Queries;
using CocktailFinderBackend.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CocktailFinder.Controllers
{
    public class FavouriteController : Controller
    {
        private readonly ILogger<FavouriteController> _logger;
        private readonly IMediator _mediator;
        public FavouriteController(IMediator mediator, ILogger<FavouriteController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        //Show favourites
        [HttpGet]
        public IActionResult Favourites()
        {
            var favouriteCocktails = _mediator.Send(new GetAllFavouritesQuery());
            if (favouriteCocktails == null)
            {
                _logger.LogWarning($"There are no favourites!!!");
            }
            return View(favouriteCocktails);
        }
        [HttpPost]
        public IActionResult AddFavourite(CocktailVM cocktail)
        {
            _mediator.Send(new AddFavouriteCommand(cocktail));

            return Ok();
        }
        [HttpDelete]
        public IActionResult RemoveFavourite(int id)
        {
            _logger.LogInformation("Remove fav handled");
            _mediator.Send(new RemoveFavouriteCommand(id));
            return Ok();
        }
        [HttpPut]
        public IActionResult EditFavourite(CocktailVM editedCocktail)
        {
            _mediator.Send(new EditFavouriteCommand(editedCocktail));
            return Ok();
        }
    }
}
