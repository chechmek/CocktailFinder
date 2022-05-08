using AutoMapper;
using CocktailDataAccess.Models;
using CocktailFinderBackend.Models;

namespace CocktailFinderBackend.Helpers.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cocktail, CocktailVM>();
            CreateMap<CocktailVM, Cocktail>();
            CreateMap<List<Cocktail>, List<CocktailVM>>();
        }
    }
}
