using CocktailDataAccessLibrary.Models;
using CocktailFinder.ApiHelper;
using CocktailFinder.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace CocktailFinderTest
{
    public class CocktailDbApiProcessorTests
    {
        CocktailDbApiProcessor processor;
        public CocktailDbApiProcessorTests()
        {
            processor = new CocktailDbApiProcessor();
        }
        [Fact]
        public void GetCocktailById_ShouldGiveCocktail()
        {
            int id = 11007;
            Cocktail expected = new Cocktail(){ Id = 11007, Name = "Margarita", Alcoholic = "Alcoholic", Category = "Ordinary Drink", Glass = "Cocktail glass", ImageUrl = @"https:\/\/www.thecocktaildb.com\/images\/media\/drink\/5noda61589575158.jpg", Instructions = "Rub the rim of the glass with the lime slice to make the salt stick to it. Take care to moisten only the outer rim and sprinkle the salt on it. The salt should present to the lips of the imbiber and never mix into the cocktail. Shake the other ingredients with ice, then carefully pour into the glass." };
            expected.Ingredients.AddRange(new Ingredient[] { new Ingredient() { Name = "Tequila" }, new Ingredient() { Name = "Triple sec" }, new Ingredient() { Name = "Lime juice" }, new Ingredient() { Name = "Salt" } });

            Cocktail actual = processor.getCocktailById(id);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void GetCocktailById_InvalidIdShouldThrowExeption()
        {
            int id = 0;
            Assert.Throws<NullReferenceException>(() => processor.getCocktailById(id));
        }
        [Fact]
        public void GetCocktailsByIngredients_ShouldGiveCocktails()
        {
            List<SearchingModel> expected = new List<SearchingModel>()
            {
                new SearchingModel(){ Name = "A Night In Old Mandalay", Id = 17832, imageUrl = @"https:\/\/www.thecocktaildb.com\/images\/media\/drink\/vyrvxt1461919380.jpg"},
                new SearchingModel(){ Name = "Blue Mountain", Id = 11119, imageUrl = @"https:\/\/ www.thecocktaildb.com\/ images\/ media\/ drink\/ bih7ln1582485506.jpg"}
            };

            var actual = processor.getCocktailsByIngredientName("Peppermint extract");

            Assert.Equal(expected, actual);
        }
    }
}