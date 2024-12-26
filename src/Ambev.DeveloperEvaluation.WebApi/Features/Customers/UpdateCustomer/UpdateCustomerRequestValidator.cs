using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.WebApi.Features.Customeres.UpdateCustomer;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.UpdateCustomer;

/// <summary>
/// Validator for CreateCustomerRequest that defines validation rules for customer creation.
/// </summary>
public class UpdateCustomerRequestValidator : AbstractValidator<UpdateCustomerRequest>
{
    public UpdateCustomerRequestValidator()
    {
        // Validates that the ExternalId is not empty and has a minimum length of 3 characters
        RuleFor(customer => customer.ExternalId).NotEmpty().WithMessage("ExternalId is required.");
        
        // Validates that the Name is not empty and has a minimum length of 3 characters
        RuleFor(customer => customer.Name).NotEmpty().WithMessage("Customer name is required.");
        
        // Validates that the Address is not empty
        RuleFor(customer => customer.Document).NotEmpty().WithMessage("Document is required.");
        
        // Validates that the City is not empty
        RuleFor(customer => customer.Email).SetValidator(new EmailValidator());
        
        // Validates that the State is not empty
        RuleFor(customer => customer.Phone).Matches(@"^\+?[1-9]\d{1,14}$");
    }
}