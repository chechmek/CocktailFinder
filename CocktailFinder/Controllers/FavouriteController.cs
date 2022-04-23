using CocktailDataAccessLibrary.DataAccess;
using CocktailDataAccessLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CocktailFinder.Controllers
{
    public class FavouriteController : Controller
    {
        private readonly CocktailDbContext _context;
        private readonly ILogger<FavouriteController> _logger;
        public FavouriteController(CocktailDbContext context, ILogger<FavouriteController> logger)
        {
            _context = context;
            _logger = logger;
        }

        //Show favourites
        [HttpGet]
        public IActionResult Favourites()
        {
            var favouriteCocktails = _context.Cocktails.ToList();
            if (favouriteCocktails == null)
            {
                _logger.LogWarning($"There are no favourites!!!");
            }
            return View(favouriteCocktails);
        }
        [HttpGet]
        public List<Cocktail> GetFavourites()
        {
            return _context.Cocktails.ToList();
        }
        [HttpPost]
        public IActionResult AddFavourite(Cocktail cocktail)
        {
            try
            {
                if (!_context.Cocktails.Any(c => c.Name == cocktail.Name))
                {
                    _context.Cocktails.Add(cocktail);
                    _context.SaveChanges();
                    _logger.LogInformation($"{cocktail.Name} added");
                    return Ok(cocktail);
                }
                else
                {
                    _logger.LogWarning($"{cocktail.Name} already exists!!!");
                    return BadRequest(cocktail);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete]
        public IActionResult RemoveFavourite(int id)
        {
            _logger.LogInformation("Remove fav handled");
            try
            {
                _context.Cocktails.Remove(new Cocktail() { Id = id });
                _context.SaveChanges();
                _logger.LogInformation($"{id} removed");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return NotFound(ex);
            }
        }
        [HttpPut]
        public IActionResult EditFavourite(Cocktail editedCocktail)
        {
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
                _context.SaveChanges();

                _logger.LogInformation($"{editedCocktail.Name} edited");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return NotFound();
            }
        }
    }
}
