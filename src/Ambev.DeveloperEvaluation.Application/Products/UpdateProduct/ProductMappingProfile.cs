using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<UpdateProductRequest, UpdateProductCommand>();
        CreateMap<Product, UpdateProductResponse>();
    }
}