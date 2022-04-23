using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailDataAccessLibrary.Models
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
