using Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItem;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.GetSaleItem;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

/// <summary>
/// Profile for mapping GetSale feature requests to commands
/// </summary>
public class GetSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetSale feature
    /// </summary>
    public GetSaleProfile()
    {
        CreateMap<GetSaleResult, GetSaleResponse>()
            .ForMember(dest => dest.Items, opt => 
            {
                opt.MapFrom(src => src.Items);
                opt.UseDestinationValue();
            })
            .PreserveReferences()
            .ReverseMap();

        CreateMap<ICollection<GetSaleItemResult>, ICollection<GetSaleItemResponse>>()
            .ConstructUsing((src, context) =>
            {
                var mappedItems = src.Select(item => context.Mapper.Map<GetSaleItemResponse>(item)).ToList();
                return mappedItems;
            });

        CreateMap<GetSaleItemResult, GetSaleItemResponse>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<Guid, GetSaleCommand>()
            .ConstructUsing(id => new GetSaleCommand(id));

        CreateMap<Sale, GetSaleResult>();
        
        CreateMap<SaleItem, GetSaleItemResult>();        
    }
}