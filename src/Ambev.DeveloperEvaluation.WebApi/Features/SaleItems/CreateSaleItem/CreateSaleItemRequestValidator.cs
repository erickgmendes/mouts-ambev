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
        // Validates that the SaleId is not empty
        RuleFor(saleItem => saleItem.SaleId).NotEmpty();

        // Validates that the ProductId is not empty
        RuleFor(saleItem => saleItem.ProductId).NotEmpty();

        // Validates that the Quantity is not empty and Greater than 0
        RuleFor(saleItem => saleItem.Quantity).NotEmpty().GreaterThan(0);
    }
}