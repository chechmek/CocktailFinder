using AutoMapper;
using CocktailDataAccess.DataAccess;
using CocktailFinderBackend.Helpers.CocktailDbApi;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CocktailFinderBackend.Common
{
    public abstract class CocktailHandlerBase 
    {
        public CocktailHandlerBase(IMediator mediator, IMapper mapper, ICocktailDbApiProcessor cocktailDbProcessor, CocktailDbContext context)
        {
            _mediator = mediator;
            _mapper = mapper;
            _cocktailApiProcessor = cocktailDbProcessor;
            _context = context;
        }

        public IMediator _mediator { get; }
        public IMapper _mapper { get; }
        public ICocktailDbApiProcessor _cocktailApiProcessor { get; }
        public CocktailDbContext _context { get; }
    }
}
