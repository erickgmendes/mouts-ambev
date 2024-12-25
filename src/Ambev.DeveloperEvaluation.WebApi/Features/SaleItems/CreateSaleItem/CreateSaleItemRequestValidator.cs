using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.CreateSaleItem;

/// <summary>
/// Validator for CreateSaleRequest that defines validation rules for sale creation.
/// </summary>
public class CreateSaleItemRequestValidator : AbstractValidator<CreateSaleItemRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleRequestValidator with defined validation rules.
    /// </summary>
    public CreateSaleItemRequestValidator()
    {
        // Validates that the Quantity is not empty and Greater than 0
        RuleFor(sale => sale.Quantity).NotEmpty().GreaterThan(0);
        
        // Validates that the UnitPrice is not empty and Greater than 0
        RuleFor(sale => sale.UnitPrice).NotEmpty().GreaterThan(0);
        
        // Validates that the Discount is not empty and Greater than or equal to 0
        RuleFor(sale => sale.Discount).NotEmpty().GreaterThanOrEqualTo(0);
        
        // Validates that the TotalAmount  is not empty and Greater than or equal to 0
        RuleFor(sale => sale.TotalAmount).NotEmpty().GreaterThanOrEqualTo(0);
        
        // Validates that the State is not empty
        RuleFor(sale => sale.ProductId).NotEmpty();
    }
}