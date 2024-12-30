using Ambev.DeveloperEvaluation.Application.SaleItems.CancelSaleItem;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.CancelSaleItem;

/// <summary>
/// Profile for mapping between Application and API CreateSaleItem responses
/// </summary>
public class CancelSaleItemProfile: Profile
{
    /// <summary>
    /// Initializes the mappings for CreateSaleItem feature
    /// </summary>
    public CancelSaleItemProfile()
    {
        CreateMap<Guid, CancelSaleItemCommand>()
            .ConstructUsing(id => new CancelSaleItemCommand(id));

        CreateMap<CancelSaleItemRequest, CancelSaleItemCommand>();     
    }
}