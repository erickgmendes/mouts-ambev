using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.CreateSaleItem;

/// <summary>
/// Validator for CreateSaleItemCommand that defines validation rules for sale creation command.
/// </summary>
public class CreateSaleItemCommandValidator: AbstractValidator<CreateSaleItemCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleItemCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Quantity is not empty and Greater than 0
    /// - UnitPrice is not empty and Greater than 0
    /// - Discount is not empty and Greater than or equal to 0
    /// - TotalAmount is not empty and Greater than or equal to 0
    /// - Product ExternalId is not empty
    /// </remarks>
    public CreateSaleItemCommandValidator()
    {
      
        // Validates that the Quantity is not empty and Greater than 0
        RuleFor(sale => sale.Quantity).NotEmpty().GreaterThan(0);
        
        // Validates that the UnitPrice is not empty and Greater than 0
        RuleFor(sale => sale.UnitPrice).NotEmpty().GreaterThan(0);
        
        // Validates that the Discount is not empty and Greater than or equal to 0
        RuleFor(sale => sale.Discount).NotEmpty().GreaterThanOrEqualTo(0);
        
        // Validates that the TotalAmount is not empty and Greater than or equal to 0
        RuleFor(sale => sale.TotalAmount).NotEmpty().GreaterThanOrEqualTo(0);
        
        // Validates that the Product ExternalId is not empty
        RuleFor(sale => sale.Product!.ExternalId).NotEmpty();
    }
}