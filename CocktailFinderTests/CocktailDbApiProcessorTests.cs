
using CocktailDataAccess.Models;
using CocktailFinderBackend.CocktailDbApi;
using CocktailFinderBackend.Models;
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
            Cocktail expected = TestData.GetCocktailById11007();

            Cocktail actual = processor.getCocktailById(11007);

            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Instructions, actual.Instructions);
            Assert.Equal(expected.Ingredients.Count, actual.Ingredients.Count);
            for (int i = 0; i < actual.Ingredients.Count; i++)
            {
                Assert.Equal(expected.Ingredients[i].Name, actual.Ingredients[i].Name);
            }
        }
        [Fact]
        public void GetCocktailById_InvalidIdShouldThrowExeption()
        {
            int id = 0;
            Assert.Throws<Exception>(() => processor.getCocktailById(id));
        }
        [Fact]
        public void GetCocktailsByIngredients_ShouldFail()
        {
            string wrongIngredient = "asd";
            Assert.Throws<Exception>(() => processor.getCocktailsByIngredientName(wrongIngredient));
        }
        [Fact]
        public void GetCocktailsByIngredients_ShouldGiveCocktails()
        {
            List<SearchingModel> expected = TestData.GetCocktailsWithChocolate();

            var actual = processor.getCocktailsByIngredientName("Chocolate");

            Assert.Equal(expected.Count, actual.Count);
            Assert.Equal(expected[0].Name, actual[0].Name);
            Assert.Equal(expected[2].Id, actual[2].Id);
        }
    }
}