using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Customers.CreateCustomers;

/// <summary>
/// Validator for CreateCustomerCommand that defines validation rules for customer creation command.
/// </summary>
public class CreateCustomerCommandValidator: AbstractValidator<CreateCustomerCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateCustomerCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - ExternalId: Required, must be between 3 and 50 characters
    /// - Name: Required, must be between 3 and 50 characters
    /// - Document: Required, must be between 3 and 50 characters
    /// - Email: Must be in valid format (using EmailValidator)
    /// - Phone: Must match international format (+X XXXXXXXXXX)
    /// </remarks>
    public CreateCustomerCommandValidator()
    {
        RuleFor(customer => customer.ExternalId).NotEmpty().Length(3, 50);
        RuleFor(customer => customer.Name).NotEmpty().Length(3, 50);
        RuleFor(customer => customer.Document).NotEmpty().Length(3, 50);
        RuleFor(customer => customer.Email).SetValidator(new EmailValidator());
        RuleFor(customer => customer.Phone).Matches(@"^\+?[1-9]\d{1,14}$");
    }
}