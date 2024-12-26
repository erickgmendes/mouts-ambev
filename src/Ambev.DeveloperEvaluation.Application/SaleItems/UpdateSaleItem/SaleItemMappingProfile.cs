using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.UpdateSaleItem;

public class SaleItemMappingProfile : Profile
{
    public SaleItemMappingProfile()
    {
        CreateMap<UpdateSaleItemRequest, UpdateSaleItemCommand>();
        CreateMap<SaleItem, UpdateSaleItemResponse>();
    }
}