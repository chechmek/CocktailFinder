using CocktailDataAccess.Models;
using CocktailFinderBackend.Models;
using System.Collections.Generic;

namespace CocktailFinderTest
{
    public static class TestData
    { 
        public static Cocktail GetCocktailById11007() 
        {
            return new Cocktail
            {
                Id = 11007,
                Name = "Margarita",
                Category = "Ordinary Drink",
                Alcoholic = "Alcoholic",
                Glass = "CocktailGlass",
                ImageUrl = "https://www.thecocktaildb.com/images/media/drink/5noda61589575158.jpg",
                Instructions = "Rub the rim of the glass with the lime slice to make the salt stick to it. Take care to moisten only the outer rim and sprinkle the salt on it. The salt should present to the lips of the imbiber and never mix into the cocktail. Shake the other ingredients with ice, then carefully pour into the glass.",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient { Id = 0, Name = "Tequila"},
                    new Ingredient { Id = 0, Name = "Triple sec"},
                    new Ingredient { Id = 0, Name = "Lime juice"},
                    new Ingredient { Id = 0, Name = "Salt"}
                }
            };
        }
        public static List<SearchingModel> GetCocktailsWithChocolate()
        {
            return new List<SearchingModel> 
            {
                new SearchingModel
                {
                    Id = 12732,
                    Name = "Chocolate Beverage",
                    imageUrl = "https://www.thecocktaildb.com/images/media/drink/jbqrhv1487603186.jpg"
                },
                new SearchingModel
                {
                    Id = 12734,
                    Name = "Chocolate Drink",
                    imageUrl = "https://www.thecocktaildb.com/images/media/drink/q7w4xu1487603180.jpg"
                },
                new SearchingModel
                {
                    Id = 12738,
                    Name = "Hot Chocolate to Die for",
                    imageUrl = "https://www.thecocktaildb.com/images/media/drink/0lrmjp1487603166.jpg"
                },
                new SearchingModel
                {
                    Id = 12748,
                    Name = "Orange Scented Hot Chocolate",
                    imageUrl = "https://www.thecocktaildb.com/images/media/drink/hdzwrh1487603131.jpg"
                },
                new SearchingModel
                {
                    Id = 12750,
                    Name = "Spanish chocolate",
                    imageUrl = "https://www.thecocktaildb.com/images/media/drink/pra8vt1487603054.jpg"
                }
            };
        }
    }
}
