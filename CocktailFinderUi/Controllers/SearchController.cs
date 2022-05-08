using CocktailFinderBackend.Common.CocktailDbApi;
using CocktailFinderBackend.Common.Queries;
using CocktailFinderBackend.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CocktailFinder.Controllers
{
    public class SearchController : Controller
    {
        private readonly ILogger<SearchController> _logger;
        private readonly IMediator _mediator;

        public SearchController(ILogger<SearchController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Error()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CocktailDetails(CocktailVM cocktailVM)
        {
            if (cocktailVM is null)
            {
                return View("NotFound");
            }
            return PartialView("_CocktailDetails", cocktailVM);
        }

        //Show all cocktails by ingredient from public API
        [HttpGet]
        public async Task<IActionResult> Cocktails(string Ingredient) //Sample: www.thecocktaildb.com/api/json/v1/1/filter.php?i=Vodka
        {
            List<SearchingModel> searchingModels = await _mediator.Send(new GetCocktailsByIngredientQuery(Ingredient));
            if (searchingModels is null)
            {
                return View("NotFound");
            }
            return PartialView("SearchQuery", searchingModels);
        }
        //Show one cocktail from public API
        [HttpGet]
        public async Task<IActionResult> Cocktail(int id) //Sample: www.thecocktaildb.com/api/json/v1/1/lookup.php?i=13940
        {
            CocktailVM? cocktailVM = await _mediator.Send(new GetCocktailByIdQuery(id));
            if (cocktailVM is null)
            {
                return View("NotFound");
            }
            return View("Cocktail", cocktailVM);
        }
        [HttpGet]
        public async Task<IActionResult> RandomCocktail()
        {
            CocktailVM cocktailVM = await _mediator.Send(new GetRandomCocktailQuery());
            
            if (cocktailVM is null)
            {
                return View("NotFound");
            }
            return View("Cocktail", cocktailVM);
            
        }

    }
}
