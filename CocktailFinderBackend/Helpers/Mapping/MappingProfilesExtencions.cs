using AutoMapper;
using CocktailDataAccess.Models;
using CocktailFinderBackend.Models;

namespace CocktailFinderBackend.Helpers.Mapping
{
    public static class MappingProfilesExtencions
    {
        public static void ConfigureMapper(this IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Cocktail, CocktailVM>();
            cfg.CreateMap<CocktailVM, Cocktail>();
            cfg.CreateMap<List<Cocktail>, List<CocktailVM>>();
        }
    }
}
