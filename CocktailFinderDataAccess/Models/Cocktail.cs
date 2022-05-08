using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CocktailDataAccess.Models
{
    public class Cocktail
    {
        public Cocktail()
        {
            Ingredients = new List<Ingredient>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Category { get; set; }
        [Required]
        [MaxLength(20)]
        public string Alcoholic { get; set; }
        [Required]
        [MaxLength(50)]
        public string Glass { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Instructions { get; set; }
        [Required]
        [MaxLength(1000)]
        public string ImageUrl { get; set; }
        public List<Ingredient> Ingredients { get; set; }

    }
}
