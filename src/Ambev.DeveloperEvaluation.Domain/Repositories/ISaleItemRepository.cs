using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for SaleItem entity operations
/// </summary>
public interface ISaleItemRepository
{
    /// <summary>
    /// Creates a new sale in the repository
    /// </summary>
    /// <param name="saleItem">The sale to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale</returns>
    Task<SaleItem> CreateAsync(SaleItem saleItem, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a sale by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the sale</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sale if found, null otherwise</returns>
    Task<SaleItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a sale from the repository
    /// </summary>
    /// <param name="id">The unique identifier of the sale to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the sale was deleted, false if not found</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Deletes a saleItem from the repository
    /// </summary>
    /// <param name="id">The unique identifier of the saleItem to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The saleItem if found, null otherwise</returns>
    Task<SaleItem?> UpdateAsync(SaleItem saleItem, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets salesItem by Sale Id 
    /// </summary>
    /// <param name="SaleId">The unique identifier of the sale</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The saleItem list if found, null otherwise</returns>
    Task<ICollection<SaleItem>> GetBySaleIdAsync(Guid saleId, CancellationToken cancellationToken);

}