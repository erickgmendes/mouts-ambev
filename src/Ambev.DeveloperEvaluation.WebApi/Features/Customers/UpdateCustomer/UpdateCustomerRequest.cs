namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.UpdateCustomer;

/// <summary>
/// Represents a request to create a new customer in the system.
/// </summary>
public class UpdateCustomerRequest
{
    /// <summary>
    /// Gets the external identifier associated with the customer, used for integrations with external systems.
    /// </summary>
    public string? ExternalId { get; set; }

    /// <summary>
    /// Gets the full name of the customer.
    /// This should not be null or empty.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Gets the customer's document number (e.g., CPF, CNPJ).
    /// Follows the format required for customer identification.
    /// </summary>
    public string? Document { get; set; }

    /// <summary>
    /// Gets the email address of the customer.
    /// Must be in a valid email format for communication and authentication purposes.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Gets the customer's phone number.
    /// Must follow the format (XX) XXXXX-XXXX.
    /// </summary>
    public string? Phone { get; set; }
    
}