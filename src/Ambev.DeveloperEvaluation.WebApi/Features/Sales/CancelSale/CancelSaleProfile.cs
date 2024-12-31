using Ambev.DeveloperEvaluation.Application.Sales.CancelSale;
using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSale;

/// <summary>
/// Profile for mapping DeleteSale feature requests to commands
/// </summary>
public class CancelSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for DeleteSale feature
    /// </summary>
    public CancelSaleProfile()
    {
        CreateMap<Guid, CancelSaleCommand>()
            .ConstructUsing(id => new CancelSaleCommand(id));

        CreateMap<CancelSaleRequest, CancelSaleCommand>();
    }
}