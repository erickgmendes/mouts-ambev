using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.UpdateSaleItem;

/// <summary>
/// Validator for CreateSaleItemRequest that defines validation rules for saleItem creation.
/// </summary>
public class UpdateSaleItemRequestValidator : AbstractValidator<UpdateSaleItemRequest>
{
    public UpdateSaleItemRequestValidator()
    {
        // Validates that the Product Id is not empty and has a minimum length of 3 characters
        RuleFor(saleItem => saleItem.ProductId).NotEmpty().WithMessage("Product Id is required.");
        
        // Validates that the Quantity is not greater than or equal to 0
        RuleFor(saleItem => saleItem.Quantity).GreaterThanOrEqualTo(0).WithMessage("Quantity is not greater than or equal to 0.");
        
        // Validates that the UnitPrice is not greater than or equal to 0
        RuleFor(saleItem => saleItem.UnitPrice).GreaterThanOrEqualTo(0).WithMessage("UnitPrice is not greater than or equal to 0.");
        
        // Validates that the Discount is not greater than or equal to 0
        RuleFor(saleItem => saleItem.Discount).GreaterThanOrEqualTo(0).WithMessage("Discount is not greater than or equal to 0.");
        
        // Validates that the TotalAmount is not greater than or equal to 0
        RuleFor(saleItem => saleItem.TotalAmount).GreaterThanOrEqualTo(0).WithMessage("TotalAmount is not greater than or equal to 0.");

        // Validates that the Status is not null
        RuleFor(saleItem => saleItem.Status).NotNull().WithMessage("Status is null.");
    }
}