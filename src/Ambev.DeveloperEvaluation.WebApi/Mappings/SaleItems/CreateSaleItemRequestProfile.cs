using Ambev.DeveloperEvaluation.Application.SaleItems.CreateSaleItem;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.CreateSaleItem;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings.SaleItems;

public class CreateSaleItemRequestProfile : Profile
{
    public CreateSaleItemRequestProfile()
    {
        CreateMap<CreateSaleItemRequest, CreateSaleItemCommand>();
        CreateMap<SaleItem, CreateSaleItemResult>();
    }
}