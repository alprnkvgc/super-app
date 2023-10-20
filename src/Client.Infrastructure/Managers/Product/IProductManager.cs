using Application.Features.Products.Queries.GetAll;
using Application.Features.Products.Queries.GetById;

namespace Client.Infrastructure.Managers.Product
{
    public interface IProductManager : IManager
    {
        Task<List<ProductsResponse>> GetAllAsync();
        Task<GetProductByIdResponse> GetByIdAsync();
    }
}
