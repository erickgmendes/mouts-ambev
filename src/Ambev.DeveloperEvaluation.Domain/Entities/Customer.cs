using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a customer with essential personal and contact information in the system.
/// </summary>
public class Customer: BaseEntity

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

    /// <summary>
    /// Initializes a new instance of the <see cref="Customer"/> class.
    /// </summary>
    public Customer() { }

    /// <summary>
    /// Performs validation of the customer entity.
    /// Checks if the required fields are properly populated.
    /// </summary>
    /// <returns>A validation result indicating whether the entity is valid.</returns>
    public ValidationResultDetail Validate()
    {
        var validator = new CustomerValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }

    /// <summary>
    /// Returns a string representation of the customer, including the name and document.
    /// </summary>
    /// <returns>A string with the customer's name and document.</returns>
    public override string ToString()
    {
        return $"Customer: {Name}, Document: {Document}";
    }

    public void Update(string name, string document, string email, string phone)
    {
        this.Name = name;
        this.Document = document;
        this.Email = name;
        this.Phone = phone;
    }
}