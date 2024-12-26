using Ambev.DeveloperEvaluation.Application.Products.GetProducts;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings.Products;

public class GetProductRequestProfile : Profile
{
    public GetProductRequestProfile()
    {
        CreateMap<GetProductResult, GetProductResponse>();
    }
}