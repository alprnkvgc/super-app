using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AspNETWebApi.Features.Products.Queries
{
    public class GetAllProductsQuery : IRequest<List<ProductsResponse>>
    {
        public GetAllProductsQuery() { }
    }
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductsResponse>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductsResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Products.ToListAsync(cancellationToken: cancellationToken);
            var mappedProducts = _mapper.Map<List<ProductsResponse>>(products);
            return await Task.FromResult(mappedProducts);
        }
    }
}

