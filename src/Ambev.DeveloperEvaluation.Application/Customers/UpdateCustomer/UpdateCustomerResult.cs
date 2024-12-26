namespace Ambev.DeveloperEvaluation.Application.Customers.UpdateCustomer;

/// <summary>
/// Response model for GetCustomer operation
/// </summary>
public class UpdateCustomerResult
{
    /// <summary>
    /// Gets the unique identifier for the customer.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets the External identifier for the customer.
    /// </summary>
    public string ExternalId { get; set; } = string.Empty;

    /// <summary>
    /// Gets the name of the customer.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets the address of the customer.
    /// </summary>
    public string Address { get; set; } = string.Empty;

    /// <summary>
    /// Gets the city where the customer is located.
    /// </summary>
    public string City { get; set; } = string.Empty;

    /// <summary>
    /// Gets the state where the customer is located.
    /// </summary>
    public string State { get; set; } = string.Empty;

    /// <summary>
    /// Gets the postal code of the customer's address.
    /// </summary>
    public string PostalCode { get; set; } = string.Empty;
}