using AutoMapper;
using CocktailDataAccess.DataAccess;
using CocktailFinderBackend.Common.Queries;
using CocktailFinderBackend.Helpers.CocktailDbApi;
using CocktailFinderBackend.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CocktailFinderBackend.Common.CocktailDbApi
{
    public class GetCocktailsByIngredientHandler : IRequestHandler<GetCocktailsByIngredientQuery, List<SearchingModel>>
    {
        private readonly IMapper _mapper;
        private readonly ICocktailDbApiProcessor _cocktailApiProcessor;
        private readonly CocktailDbContext _context;
        public GetCocktailsByIngredientHandler(IMapper mapper, ICocktailDbApiProcessor cocktailDbProcessor, CocktailDbContext context)
        {
            _mapper = mapper;
            _cocktailApiProcessor = cocktailDbProcessor;
            _context = context;
        }

        public async Task<List<SearchingModel>> Handle(GetCocktailsByIngredientQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var searchingModels = _cocktailApiProcessor.getCocktailsByIngredientName(request.Ingredient);
                return searchingModels;
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "Error ocured");
                return null;
            }
        }
    }
}
