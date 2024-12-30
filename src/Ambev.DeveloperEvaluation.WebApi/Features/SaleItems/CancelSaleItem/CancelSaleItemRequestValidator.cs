using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.CancelSaleItem;

/// <summary>
/// Validator for CreateSaleItemRequest that defines validation rules for saleItem creation.
/// </summary>
public class CancelSaleItemRequestValidator : AbstractValidator<CancelSaleItemRequest>
{
    public CancelSaleItemRequestValidator()
    {
        // Validates that the Sale Item Id is not empty and has a minimum length of 3 characters
        RuleFor(saleItem => saleItem.Id).NotEmpty().WithMessage("Sale Item Id is required.");
    }
}