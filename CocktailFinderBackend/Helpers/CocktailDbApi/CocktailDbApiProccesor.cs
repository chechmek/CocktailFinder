using CocktailDataAccess.Models;
using CocktailFinderBackend.Models;
using CocktailFinderBackend.Helpers.WebHelper;
using Newtonsoft.Json.Linq;
using CocktailFinderBackend.Helpers.CocktailDbApi;

namespace CocktailFinderBackend.CocktailDbApi
{
    public class CocktailDbApiProcessor : ICocktailDbApiProcessor
    {
        private readonly HttpWorker httpWorker;

        public CocktailDbApiProcessor()
        {
            httpWorker = new HttpWorker();
        }
        public Cocktail getCocktailById(int id)
        {
            try
            {
                string url = cocktailSearchUrl(id);
                string response = httpWorker.GetJsonResponse(url).Result;

                var cocktail = ParseCocktailModel(response);

                return cocktail;

            }
            catch
            {
                throw new Exception($"Id is not valid: {id}");
            }


        }
        public List<SearchingModel> getCocktailsByIngredientName(string name)
        {
            try
            {
                string url = ingredientSearchUrl(name);
                string response = httpWorker.GetJsonResponse(url).Result;
                var searching = ParseSearchingModel(response);

                return searching;
            }
            catch
            {
                throw new Exception($"Ingredient is not valid: {name}");
            }

        }
        public Cocktail getRandomCocktail()
        {
            string url = randomSearchUrl();
            string response = httpWorker.GetJsonResponse(url).Result;
            var cocktail = ParseCocktailModel(response);

            return cocktail;
        }
        private string cocktailSearchUrl(int id) => $"http://www.thecocktaildb.com/api/json/v1/1/lookup.php?i={id}";
        private string ingredientSearchUrl(string i) => @$"http://www.thecocktaildb.com/api/json/v1/1/filter.php?i={i}";
        private string randomSearchUrl() => @$"http://www.thecocktaildb.com/api/json/v1/1/random.php";
        private List<SearchingModel>? ParseSearchingModel(string json)
        {
            List<SearchingModel> searchingModels = new List<SearchingModel>();



            JObject cocktails = JObject.Parse(json);
            var cocktailsArray =
                from c in cocktails["drinks"]
                select c;
            foreach (var item in cocktailsArray)
            {
                SearchingModel s = new SearchingModel { Id = (int)item["idDrink"], Name = (string)item["strDrink"], imageUrl = (string)item["strDrinkThumb"] };
                searchingModels?.Add(s);
            }
            if (searchingModels == null)
                return null;



            return searchingModels;
        }
        private Cocktail? ParseCocktailModel(string json)
        {
            JObject? cocktailJsonRaw = JObject.Parse(json);
            JArray? cocktailJsonArray = (JArray?)cocktailJsonRaw["drinks"];
            JObject? cocktailJson;

            cocktailJson = (JObject?)cocktailJsonArray[0];

            Cocktail cocktail = new Cocktail()
            {
                Id = (int)cocktailJson["idDrink"],
                Name = (string?)cocktailJson["strDrink"],
                ImageUrl = (string?)cocktailJson["strDrinkThumb"],
                Category = (string?)cocktailJson["strCategory"],
                Alcoholic = (string?)cocktailJson["strAlcoholic"],
                Glass = (string?)cocktailJson["strGlass"],
                Instructions = (string?)cocktailJson["strInstructions"]
            };
            for (int i = 1; i <= 15; i++)
            {
                string? ingredient = (string?)cocktailJson[$"strIngredient{i}"];
                if (String.IsNullOrWhiteSpace(ingredient))
                {
                    continue;
                }
                cocktail.Ingredients.Add(new Ingredient { Name = ingredient });
            }

            return cocktail;
        }
    }
}
