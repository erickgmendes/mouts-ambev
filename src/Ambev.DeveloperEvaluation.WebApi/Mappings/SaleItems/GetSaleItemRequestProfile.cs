using Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItem;
using Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.GetSaleItem;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings.SaleItems;

public class GetSaleItemRequestProfile : Profile
{
    public GetSaleItemRequestProfile()
    {
        CreateMap<GetSaleItemResult, GetSaleItemResponse>();
    }
}