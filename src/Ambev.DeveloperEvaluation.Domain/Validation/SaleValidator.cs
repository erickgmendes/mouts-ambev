using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {
        RuleFor(sale => sale.Number)
            .NotEmpty().WithMessage("Sale number is required.")
            .MaximumLength(50).WithMessage("Sale number cannot be longer than 50 characters.");

        RuleFor(sale => sale.Date)
            .NotEmpty().WithMessage("Sale date is required.")
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Sale date cannot be in the future.");

        RuleFor(sale => sale.Customer)
            .NotNull().WithMessage("Customer is required.");

        RuleFor(sale => sale.Branch)
            .NotNull().WithMessage("Branch is required.");

        RuleFor(sale => sale.TotalAmount)
            .GreaterThan(0).WithMessage("Total amount must be greater than zero.");

        RuleFor(sale => sale.Items)
            .NotEmpty().WithMessage("Sale must have at least one item.")
            .Must(items => items.All(item => item.Quantity > 0 && item.UnitPrice > 0))
            .WithMessage("Each sale item must have a valid quantity and price.");

        RuleFor(sale => sale.IsCancelled)
            .NotNull().WithMessage("Sale cancellation status is required.");

        RuleFor(sale => sale.CreatedAt)
            .NotEmpty().WithMessage("Sale creation date is required.");

        RuleFor(sale => sale.UpdatedAt)
            .GreaterThan(sale => sale.CreatedAt).When(sale => sale.UpdatedAt.HasValue)
            .WithMessage("Sale update date must be after the creation date.");
    }
}