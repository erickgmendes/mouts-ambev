using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

/// <summary>
/// Validator for CreateSaleRequest that defines validation rules for sale creation.
/// </summary>
public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
{
    public UpdateSaleRequestValidator()
    {
        RuleFor(sale => sale.Number).NotEmpty().WithMessage("Number is required.");
        RuleFor(sale => sale.Date).NotEmpty().WithMessage("Date is required.");
        RuleFor(sale => sale.CustomerId).NotEmpty().WithMessage("Customer Id is required.");
        RuleFor(sale => sale.BranchId).NotEmpty().WithMessage("Branch Id is required.");
    }
}