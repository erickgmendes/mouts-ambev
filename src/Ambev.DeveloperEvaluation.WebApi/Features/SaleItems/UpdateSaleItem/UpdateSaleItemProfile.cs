using Ambev.DeveloperEvaluation.Application.SaleItems.UpdateSaleItem;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.UpdateSaleItem;

/// <summary>
/// Profile for mapping between Application and API CreateSaleItem responses
/// </summary>
public class UpdateSaleItemProfile: Profile
{
    /// <summary>
    /// Initializes the mappings for CreateSaleItem feature
    /// </summary>
    public UpdateSaleItemProfile()
    {
        CreateMap<UpdateSaleItemRequest, UpdateSaleItemCommand>();
        CreateMap<UpdateSaleItemResult, UpdateSaleItemResponse>();
        CreateMap<UpdateSaleItemCommand, SaleItem>();
    }
}