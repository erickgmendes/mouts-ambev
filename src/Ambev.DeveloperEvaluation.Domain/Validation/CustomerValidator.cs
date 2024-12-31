using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(customer => customer.Name)
            .NotEmpty().WithMessage("Customer name is required.")
            .MaximumLength(100).WithMessage("Customer name cannot be longer than 100 characters.");

        RuleFor(customer => customer.Document)
            .NotEmpty().WithMessage("Customer document is required.")
            .Matches(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$|^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$")
            .WithMessage("Customer document must be in a valid CPF or CNPJ format.");

        RuleFor(customer => customer.Email)
            .NotEmpty().WithMessage("Customer email is required.")
            .EmailAddress().WithMessage("Customer email must be in a valid format.");

        RuleFor(customer => customer.Phone)
            .Matches(@"^\(\d{2}\) \d{5}-\d{4}$")
            .WithMessage("Customer phone must follow the format (XX) XXXXX-XXXX.");
            
        RuleFor(customer => customer.ExternalId)
            .NotEmpty().WithMessage("External Id is required.")
            .MaximumLength(50).WithMessage("External Id cannot be longer than 50 characters.");
    }
}