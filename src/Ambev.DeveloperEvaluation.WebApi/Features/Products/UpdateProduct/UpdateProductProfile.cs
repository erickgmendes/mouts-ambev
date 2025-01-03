using Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;

/// <summary>
/// Profile for mapping between Application and API CreateProduct responses
/// </summary>
public class UpdateProductProfile: Profile
{
    /// <summary>
    /// Initializes the mappings for CreateProduct feature
    /// </summary>
    public UpdateProductProfile()
    {
        CreateMap<UpdateProductRequest, UpdateProductCommand>();
        CreateMap<Product, UpdateProductResult>();
        CreateMap<UpdateProductResult, UpdateProductResponse>();
    }
}