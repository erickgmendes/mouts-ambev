using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProduct;

/// <summary>
/// Profile for mapping DeleteProduct feature requests to commands
/// </summary>
public class DeleteProductProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for DeleteProduct feature
    /// </summary>
    public DeleteProductProfile()
    {
        CreateMap<Guid, Application.Products.DeleteProducts.DeleteProductCommand>()
            .ConstructUsing(id => new Application.Products.DeleteProducts.DeleteProductCommand(id));
    }
}