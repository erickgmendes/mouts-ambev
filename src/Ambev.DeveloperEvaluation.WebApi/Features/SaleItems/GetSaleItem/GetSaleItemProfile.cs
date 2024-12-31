using Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItem;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.GetSaleItem;

/// <summary>
/// Profile for mapping GetSale feature requests to commands
/// </summary>
public class GetSaleItemProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetSale feature
    /// </summary>
    public GetSaleItemProfile()
    {
        CreateMap<Guid, GetSaleItemCommand>().ConstructUsing(id => new GetSaleItemCommand(id));
        CreateMap<SaleItem, GetSaleItemResult>();
        CreateMap<GetSaleItemResult, GetSaleItemResponse>();

        CreateMap<SaleItem, GetSaleItemResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.SaleId, opt => opt.MapFrom(src => src.Sale.Id))
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Product.Id))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalAmount));
    }
}