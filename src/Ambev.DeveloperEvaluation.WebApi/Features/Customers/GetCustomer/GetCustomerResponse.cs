namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.GetCustomer;

public class GetCustomerResponse
{
    /// <summary>
    /// Gets the unique identifier for the customer.
    /// </summary>
    public Guid Id { get; set; }

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

}