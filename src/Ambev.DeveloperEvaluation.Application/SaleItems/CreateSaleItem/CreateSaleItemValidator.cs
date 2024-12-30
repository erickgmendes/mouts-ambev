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
    /// - SaleId is not empty
    /// - ProductId is not empty
    /// - Quantity is not empty and Greater than 0
    /// </remarks>
    public CreateSaleItemCommandValidator()
    {
        // Validates that the SaleId is not empty
        RuleFor(saleItem => saleItem.SaleId).NotEmpty();
        
        // Validates that the ProductId is not empty
        RuleFor(saleItem => saleItem.ProductId).NotEmpty();

        // Validates that the Quantity is not empty and Greater than 0
        RuleFor(saleItem => saleItem.Quantity)
            .GreaterThan(0).WithMessage("Quantity cannot be less than or equal to 0")
            .LessThanOrEqualTo(20).WithMessage("Quantity cannot be greater than or equal to 20");
    }
}