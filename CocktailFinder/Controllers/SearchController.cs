using CocktailDataAccessLibrary.DataAccess;
using CocktailDataAccessLibrary.Models;
using CocktailFinder.ApiHelper;
using CocktailFinder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CocktailFinder.Controllers
{
    public class SearchController : Controller
    {
        private readonly ILogger<SearchController> _logger;
        private readonly CocktailDbContext _context;
        private readonly CocktailDbApiProcessor _cocktailApiProcessor;
        public SearchController(CocktailDbContext context, ILogger<SearchController> logger, CocktailDbApiProcessor processor)
        {
            _logger = logger;
            _context = context;
            _cocktailApiProcessor = processor;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
        public IActionResult CocktailDetails(CocktailVM cocktailVM)
        {
            return PartialView("_CocktailDetails", cocktailVM);
        }

        //Show all cocktails by ingredient from public API
        public IActionResult Cocktails(string Ingredient) //Sample: www.thecocktaildb.com/api/json/v1/1/filter.php?i=Vodka
        {
            //get search results
            List<SearchingModel> searchingModels = new List<SearchingModel>();

            try
            {
                searchingModels = _cocktailApiProcessor.getCocktailsByIngredientName(Ingredient);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error ocured");
            }
            //Expose the view
            return PartialView("SearchQuery", searchingModels);
        }
        //Show one cocktail from public API
        public IActionResult Cocktail(int id) //Sample: www.thecocktaildb.com/api/json/v1/1/lookup.php?i=13940
        {
            Cocktail? cocktail = new Cocktail();
            CocktailVM? cocktailVM = new CocktailVM();

            try
            {
                //Check if it is in favourites (for the view of button)
                cocktailVM.InFavourites = _context.Cocktails.Any(c => c.Id == id);
                if (cocktailVM.InFavourites)
                {
                    cocktail = _context.Cocktails.Include(c => c.Ingredients).FirstOrDefault(c => c.Id == id);
                    if (cocktail is not null)
                    {
                        cocktail.Ingredients.ForEach((i) =>
                        {
                            i.Id = 0;
                            i.Cocktails.Clear();
                        });
                        cocktailVM.Cocktail = cocktail;

                    }
                }
                else
                {
                    //Call api for the cocktail by id
                    cocktail = _cocktailApiProcessor.getCocktailById(id);
                    cocktailVM.Cocktail = cocktail;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return View("NotFound", ex.Message);
            }

            return View("Cocktail", cocktailVM);
        }
        public IActionResult RandomCocktail()
        {
            CocktailVM cocktailVM = new CocktailVM();
            try
            {
                cocktailVM.Cocktail = _cocktailApiProcessor.getRandomCocktail();
                cocktailVM.InFavourites = _context.Cocktails.Any(c => c.Id == cocktailVM.Cocktail.Id);
                
                return View("Cocktail", cocktailVM);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return View("NotFound", ex.Message);
            }
            
        }

    }
}
