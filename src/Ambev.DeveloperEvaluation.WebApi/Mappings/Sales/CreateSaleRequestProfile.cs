using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings.Sales;

public class CreateSaleRequestProfile : Profile
{
    public CreateSaleRequestProfile()
    {
        CreateMap<CreateSaleRequest, CreateSaleCommand>();
        CreateMap<Sale, CreateSaleResult>();
    }
}