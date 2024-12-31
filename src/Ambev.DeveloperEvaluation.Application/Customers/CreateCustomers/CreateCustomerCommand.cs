using Ambev.DeveloperEvaluation.Common.Validation;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customers.CreateCustomers;

/// <summary>
/// Command for creating a new customer.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a customer, 
/// including customername, password, phone number, email, status, and role. 
/// It implements <see cref="IRequest"/> to initiate the request 
/// that returns a <see cref="CreateCustomerResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="CreateCustomerValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class CreateCustomerCommand : IRequest<CreateCustomerResult>
{
    /// <summary>
    /// Gets the external identifier associated with the customer, used for integrations with external systems.
    /// </summary>
    public string ExternalId { get; set; } = string.Empty;

    /// <summary>
    /// Gets the full name of the customer.
    /// This should not be null or empty.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets the customer's document number (e.g., CPF, CNPJ).
    /// Follows the format required for customer identification.
    /// </summary>
    public string Document { get; set; } = string.Empty;

    /// <summary>
    /// Gets the email address of the customer.
    /// Must be in a valid email format for communication and authentication purposes.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets the customer's phone number.
    /// Must follow the format (XX) XXXXX-XXXX.
    /// </summary>
    public string Phone { get; set; } = string.Empty;

    public ValidationResultDetail Validate()
    {
        var validator = new CreateCustomerCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}