using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.CancelSaleItem;

/// <summary>
/// Validator for CancelSaleCommand
/// </summary>
public class CancelSaleItemValidator : AbstractValidator<CancelSaleItemCommand>
{
    /// <summary>
    /// Initializes validation rules for CancelSaleItemCommand
    /// </summary>
    public CancelSaleItemValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Sale item ID is required");
    }
}