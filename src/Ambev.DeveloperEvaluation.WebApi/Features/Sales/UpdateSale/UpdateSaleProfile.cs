using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

/// <summary>
/// Profile for mapping between Application and API CreateSale responses
/// </summary>
public class UpdateSaleProfile: Profile
{
    /// <summary>
    /// Initializes the mappings for CreateSale feature
    /// </summary>
    public UpdateSaleProfile()
    {
        CreateMap<UpdateSaleRequest, UpdateSaleCommand>();
        CreateMap<Sale, UpdateSaleResult>();
        CreateMap<UpdateSaleResult, UpdateSaleResponse>();
    }
}