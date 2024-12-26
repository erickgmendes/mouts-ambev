using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of ISaleItemRepository using Entity Framework Core
/// </summary>
public class SaleItemRepository: ISaleItemRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of SaleItemRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public SaleItemRepository(DefaultContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new sale in the database
    /// </summary>
    /// <param name="sale">The sale to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale</returns>
    public async Task<SaleItem> CreateAsync(SaleItem sale, CancellationToken cancellationToken = default)
    {
        await _context.SaleItems.AddAsync(sale, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return sale;
    }

    /// <summary>
    /// Retrieves a sale by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the sale</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sale if found, null otherwise</returns>
    public async Task<SaleItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.SaleItems
            .Include(x=>x.Sale)
            .Include(x=>x.Product)
            .FirstOrDefaultAsync(o=> o.Id == id, cancellationToken);
    }

    public async Task<SaleItem?> GetByExternalIdAsync(string externalId, CancellationToken cancellationToken = default)
    {
        return await _context.SaleItems.FirstOrDefaultAsync(s=> s.Product.ExternalId == externalId, cancellationToken);
    }

    /// <summary>
    /// Deletes a sale from the database
    /// </summary>
    /// <param name="id">The unique identifier of the sale to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the sale was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var sale = await GetByIdAsync(id, cancellationToken);
        if (sale == null)
            return false;

        _context.SaleItems.Remove(sale);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
    
    /// <summary>
    /// Deletes a saleItem from the database
    /// </summary>
    /// <param name="id">The unique identifier of the saleItem to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the saleItem was deleted, false if not found</returns>
    public async Task<SaleItem?> UpdateAsync(SaleItem? saleItem, CancellationToken cancellationToken = default)
    {
        if (saleItem == null)
            return null;

        _context.SaleItems.Update(saleItem);
        await _context.SaveChangesAsync(cancellationToken);
        return saleItem;
    }
}