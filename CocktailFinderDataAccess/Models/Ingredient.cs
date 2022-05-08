using System.ComponentModel.DataAnnotations;

namespace CocktailDataAccess.Models
{
    public class Ingredient
    {
        public Ingredient()
        {
            Cocktails = new List<Cocktail>();
        }
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public List<Cocktail> Cocktails { get; set; }
    }
}
