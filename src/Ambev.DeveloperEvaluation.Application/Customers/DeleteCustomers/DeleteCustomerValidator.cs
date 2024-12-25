using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Customers.DeleteCustomers;

/// <summary>
/// Validator for DeleteCustomerCommand
/// </summary>
public class DeleteCustomerValidator : AbstractValidator<DeleteCustomerCommand>
{
    /// <summary>
    /// Initializes validation rules for DeleteCustomerCommand
    /// </summary>
    public DeleteCustomerValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Customer ID is required");
    }
}