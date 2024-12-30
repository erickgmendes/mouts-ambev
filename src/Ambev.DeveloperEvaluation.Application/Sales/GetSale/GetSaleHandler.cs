using System.ComponentModel.DataAnnotations.Schema;
using Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItem;
using Ambev.DeveloperEvaluation.Application.Sales.DiscountStrategies;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Handler for processing GetSaleCommand requests
/// </summary>
public class GetSaleHandler : IRequestHandler<GetSaleCommand, GetSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetSaleHandler
    /// </summary>
    /// <param name="saleRepository">The sale repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for GetSaleCommand</param>
    public GetSaleHandler(
        ISaleRepository saleRepository,
        IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetSaleCommand request
    /// </summary>
    /// <param name="request">The GetSale command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sale details if found</returns>
    public async Task<GetSaleResult> Handle(GetSaleCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetSaleValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var sale = await _saleRepository.GetByIdAsync(request.Id, cancellationToken);
        if (sale == null)
            throw new KeyNotFoundException($"Sale with ID {request.Id} not found");

        var saleResult = _mapper.Map<GetSaleResult>(sale);
        var distinctItems = saleResult.Items
            .GroupBy(item => item.ProductId)
            .Select(group => group.First())
            .ToList();
        foreach (var item in distinctItems)
        {
            var itens = saleResult.Items.Where(item => item.ProductId == item.ProductId).ToList();
            var quantity = itens.Sum(x => x.Quantity);

            foreach (var getSaleItemResult in itens)
            {
                IDiscountStrategy discountRuleStrategy;
                if (quantity >= 10 && quantity <= 20)
                    discountRuleStrategy = new DiscountBetween10And20ItemsStrategy();
                else if (quantity >= 4)
                    discountRuleStrategy = new DiscountForMoreThan4ItemsStrategy();
                else
                    discountRuleStrategy = new NoDiscountStrategy();

                getSaleItemResult.Discount = discountRuleStrategy.ApplyDiscount(getSaleItemResult.TotalAmount);
                getSaleItemResult.TotalAmount -= getSaleItemResult.Discount;
            }
        }

        return saleResult;
    }
}