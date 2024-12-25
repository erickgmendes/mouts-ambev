namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.CreateCustomer;

/// <summary>
/// Profile for mapping between Application and API CreateCustomer responses
/// </summary>
public class CreateCustomerResponse
{
    /// <summary>
    /// Gets the unique identifier for the customer.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets the external identifier associated with the customer, used for integrations with external systems.
    /// </summary>
    public string ExternalId { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the full name of the customer.
    /// This should not be null or empty.
    /// </summary>
    public string Name { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the customer's document number (e.g., CPF, CNPJ).
    /// Follows the format required for customer identification.
    /// </summary>
    public string Document { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the email address of the customer.
    /// Must be in a valid email format for communication and authentication purposes.
    /// </summary>
    public string Email { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the customer's phone number.
    /// Must follow the format (XX) XXXXX-XXXX.
    /// </summary>
    public string Phone { get; private set; } = string.Empty;
    
}