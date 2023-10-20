using Application.Features.Products.Commands;
using Application.Features.Products.Queries.GetAll;
using Application.Features.Products.Queries.GetById;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductsResponse, Product>().ReverseMap();
            CreateMap<GetProductByIdResponse, Product>().ReverseMap();
            CreateMap<CreateUpdateProductCommand, Product>().ReverseMap();
        }
    }
}
